//document.addEventListener('DOMContentLoaded', function () {
//    var userName = prompt("Enter your name:");

//    var messageInput = document.getElementById("messageInp");
//    var groupInput = document.getElementById("groupNameInp");
//    var messageToGroupInput = document.getElementById("messageToGroupInp");

//    messageInput.focus();

//    // Define Proxy
//    var proxyConnection = new signalR.HubConnectionBuilder().withUrl("/chat").build();

//    proxyConnection.start().then(function () {
//        document.getElementById("sendMessageBtn").addEventListener("click", function (e) {
//            e.preventDefault();
//            var message = messageInput.value;

//            proxyConnection.invoke("Send", userName, message);
//            displayOneOnOneMessage(userName, message, true); // Display sent one-on-one message in blue and align to the right
//            messageInput.value = '';
//        });

//        document.getElementById("joinGroupBtn").addEventListener("click", function (e) {
//            e.preventDefault();
//            proxyConnection.invoke("JoinGroup", groupInput.value, userName);
//        });

//        document.getElementById("sendMessageToGroupBtn").addEventListener("click", function (e) {
//            e.preventDefault();
//            var groupMessage = messageToGroupInput.value;
//            proxyConnection.invoke("SendMessageToGroup", groupInput.value, userName, groupMessage);
//            displayGroupMessage(userName, groupMessage, true); // Display sent group message in blue and align to the right
//            messageToGroupInput.value = ''; // Clear the input field after sending
//        });
//    }).catch(function (error) {
//        console.log(error);
//    });

//    proxyConnection.on("ReceiveMessage", function (senderName, message) {
//        displayOneOnOneMessage(senderName, message, false); // Display received one-on-one message in red and align to the left
//    });

//    proxyConnection.on("ReceiveMessageFromGroup", function (message, sender) {
//        displayGroupMessage(sender, message, false); // Display received group message in red and align to the left
//    });

//    function displayOneOnOneMessage(userName, message, isSent) {
//        var liElement = document.createElement("li");

//        if (isSent) {
//            liElement.style.color = "blue"; // Set the text color to blue for sent messages
//            liElement.style.textAlign = "right"; // Align sent messages to the right
//            liElement.innerHTML = `${message} <strong> :You</strong>`;
//        } else {
//            liElement.style.color = "red"; // Set the text color to red for received messages
//            liElement.style.textAlign = "left"; // Align received messages to the left
//            liElement.innerHTML = `<strong>${userName}:</strong> ${message}`;
//        }

//        document.getElementById("conversation").appendChild(liElement);
//    }

//    function displayGroupMessage(userName, message, isSent) {
//        var liElement = document.createElement("li");

//        if (isSent) {
//            liElement.style.color = "blue"; // Set the text color to blue for sent messages
//            liElement.style.textAlign = "right"; // Align sent messages to the right
//            liElement.innerHTML = `${message} <strong> :You</strong> `;
//        } else {
//            liElement.style.color = "red"; // Set the text color to red for received messages
//            liElement.style.textAlign = "left"; // Align received messages to the left
//            liElement.innerHTML = `<strong>${userName}:</strong> ${message}`;
//        }

//        document.getElementById("groupConversationUL").appendChild(liElement);
//    }

//    proxyConnection.on("NewMemeberJoin", function (userName, groupName) {
//        var liElement = document.createElement("li");
//        liElement.innerHTML = `<i>${userName} has joined </i> ${groupName}`;
//        document.getElementById("groupConversationUL").appendChild(liElement);
//    });
//});



// Chat functionality with enhanced features
class ChatApp {
    constructor() {
        this.connection = null;
        this.userName = '';
        this.init();
    }

    async init() {
        this.userName = prompt("Enter your name:") || "Anonymous";
        this.setupConnection();
        this.setupEventListeners();
        this.requestNotificationPermission();
    }

    setupConnection() {
        this.connection = new signalR.HubConnectionBuilder()
            .withUrl("/chat")
            .withAutomaticReconnect()
            .build();

        this.connection.start()
            .then(() => {
                this.updateStatus(true);
                this.playSound('connect');
            })
            .catch(err => console.error(err));

        this.connection.on("ReceiveMessage", (sender, message) => {
            this.displayMessage(sender, message, false);
            this.showNotification(sender, message);
            this.playSound('message');
        });

        this.connection.onreconnecting(() => this.updateStatus(false));
        this.connection.onreconnected(() => this.updateStatus(true));
    }

    setupEventListeners() {
        const sendBtn = document.getElementById('sendBtn');
        const messageInput = document.getElementById('messageInput');

        sendBtn?.addEventListener('click', () => this.sendMessage());
        messageInput?.addEventListener('keypress', (e) => {
            if (e.key === 'Enter') this.sendMessage();
        });
    }

    async sendMessage() {
        const input = document.getElementById('messageInput');
        const message = input.value.trim();

        if (!message) return;

        try {
            await this.connection.invoke("Send", this.userName, message);
            this.displayMessage(this.userName, message, true);
            input.value = '';
            this.playSound('send');
        } catch (err) {
            console.error(err);
        }
    }

    displayMessage(sender, message, isSent) {
        const container = document.getElementById('messagesContainer');
        const messageDiv = document.createElement('div');
        messageDiv.className = `message ${isSent ? 'sent' : 'received'}`;

        const content = isSent
            ? `${message} <strong>You</strong>`
            : `<strong>${sender}:</strong> ${message}`;

        messageDiv.innerHTML = content;
        container.appendChild(messageDiv);
        container.scrollTop = container.scrollHeight;
    }

    updateStatus(connected) {
        const indicator = document.querySelector('.status-indicator');
        if (indicator) {
            indicator.style.background = connected ? '#10b981' : '#ef4444';
        }
    }

    playSound(type) {
        const audio = new Audio(`/sounds/${type}.mp3`);
        audio.volume = 0.3;
        audio.play().catch(() => { });
    }

    async requestNotificationPermission() {
        if ('Notification' in window && Notification.permission === 'default') {
            await Notification.requestPermission();
        }
    }

    showNotification(sender, message) {
        if ('Notification' in window && Notification.permission === 'granted') {
            new Notification(`New message from ${sender}`, {
                body: message,
                icon: '/icon.png'
            });
        }
    }
}

// Initialize app when DOM is ready
document.addEventListener('DOMContentLoaded', () => new ChatApp());
