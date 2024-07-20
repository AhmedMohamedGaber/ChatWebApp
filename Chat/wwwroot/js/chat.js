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
