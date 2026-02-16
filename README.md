# ChatHub - Real-Time Chat Application

<div align="center">

![ChatHub Logo](https://img.shields.io/badge/ChatHub-Real--Time%20Chat-6366f1?style=for-the-badge&logo=chat&logoColor=white)

[![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-6.0-512BD4?style=flat-square&logo=.net)](https://dotnet.microsoft.com/)
[![SignalR](https://img.shields.io/badge/SignalR-Real--Time-00ADD8?style=flat-square)](https://dotnet.microsoft.com/apps/aspnet/signalr)
[![License](https://img.shields.io/badge/License-MIT-green?style=flat-square)](LICENSE)
[![Build Status](https://img.shields.io/badge/Build-Passing-brightgreen?style=flat-square)](https://github.com/AhmedMohamedGaber/ChatWebApp)

**A modern, real-time chat application built with ASP.NET Core and SignalR**

[Live Demo](https://randomchat.runasp.net/) · [Report Bug](https://github.com/AhmedMohamedGaber/ChatWebApp/issues) · [Request Feature](https://github.com/AhmedMohamedGaber/ChatWebApp/issues)

</div>

---

## 📸 Screenshots

### Landing Page
<img width="100%" src="https://github.com/user-attachments/assets/da7ed107-a22d-450b-9d5c-ba8e99af24de" />
<p><em>Modern landing page with smooth animations and professional design</em></p>

### Live Chat Interface
<img width="600" src="https://github.com/user-attachments/assets/064bb457-164e-4af3-8b39-3df154784a2a" />
<p><em>Real-time one-on-one chat with message timestamps and online users counter</em></p>

### Group Chat
<img width="600" src="https://github.com/user-attachments/assets/bad262da-6902-4488-8b22-942ef7f471b2" />
<p><em>Create and join group conversations with multiple users</em></p>

*Create and join group conversations with multiple users*

---

## ✨ Features

### 🚀 Core Features
- **Real-Time Messaging** - Instant message delivery using SignalR WebSockets
- **One-on-One Chat** - Private conversations between users
- **Group Chat** - Create and join group conversations
- **Online Users Tracking** - See how many users are currently online
- **Message Timestamps** - Every message shows when it was sent
- **Typing Indicators** - See when someone is typing
- **Auto-Reconnection** - Automatically reconnects if connection is lost

### 🎨 User Experience
- **Professional UI/UX** - Modern, clean interface with smooth animations
- **Glassmorphism Design** - Beautiful glass-effect cards and modals
- **Dark Theme** - Easy on the eyes with a premium dark color scheme
- **Responsive Design** - Works perfectly on desktop, tablet, and mobile
- **LocalStorage Support** - Remembers your name (no need to re-enter)
- **Desktop Notifications** - Get notified of new messages
- **Sound Notifications** - Audio alerts for incoming messages

### 🔧 Technical Features
- **ASP.NET Core 6.0** - Modern, cross-platform framework
- **SignalR** - Real-time bidirectional communication
- **Dependency Injection** - Clean architecture with DI
- **Service Layer** - Separation of concerns with dedicated services
- **Connection Tracking** - Thread-safe user connection management
- **Comprehensive Logging** - Detailed logging for debugging
- **Error Handling** - Graceful error handling throughout

---

## 🛠️ Tech Stack

### Backend
- **Framework**: ASP.NET Core 6.0
- **Real-Time**: SignalR
- **Database**: SQL Server (Entity Framework Core)
- **Architecture**: Clean Architecture with Service Layer

### Frontend
- **HTML5** - Semantic markup
- **CSS3** - Modern styling with animations
- **JavaScript (ES6+)** - Client-side logic
- **SignalR Client** - Real-time communication

### Design
- **Google Fonts** (Inter) - Modern typography
- **CSS Variables** - Easy theming
- **Flexbox & Grid** - Responsive layouts
- **Animations** - Smooth transitions and effects

---

## 📋 Prerequisites

Before you begin, ensure you have the following installed:
- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) or later
- [SQL Server](https://www.microsoft.com/sql-server/sql-server-downloads) (LocalDB or Express)
- A modern web browser (Chrome, Firefox, Edge, Safari)
- [Git](https://git-scm.com/) (for cloning the repository)

---

## 🚀 Getting Started

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/AhmedMohamedGaber/ChatWebApp.git
   cd ChatWebApp/Chat
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Update database connection string** (if needed)
   
   Edit `appsettings.json` or the connection string in `Contexts/ChattingDbContext.cs`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "server=.; database=Chat; integrated security=true;"
   }
   ```

4. **Run database migrations** (if using database)
   ```bash
   dotnet ef database update
   ```

5. **Build the project**
   ```bash
   dotnet build
   ```

6. **Run the application**
   ```bash
   dotnet run
   ```

7. **Open your browser**
   
   Navigate to: `https://localhost:7042` or `http://localhost:5042`

---

## 📖 Usage

### Starting a Chat

1. **Visit the landing page** at `https://localhost:7042`
2. **Click "Start Chatting Now"** or **"Join Group Chat"**
3. **Enter your name** in the modal (it will be saved for next time)
4. **Start chatting!**

### Changing Your Name

- Click on your name badge in the header
- Enter a new name
- Your new name will be saved automatically

### Joining a Group

1. Navigate to the **Group Chat** page
2. Enter a **group name**
3. Click **"Join Group"**
4. Start chatting with everyone in the group!

---

## 🏗️ Project Structure

```
Chat/
├── Controllers/          # MVC Controllers
│   └── HomeController.cs
├── Hubs/                # SignalR Hubs
│   └── ChatHub.cs
├── Services/            # Business Logic Services
│   ├── IConnectionTracker.cs
│   ├── ConnectionTracker.cs
│   ├── IMessageService.cs
│   └── MessageService.cs
├── Models/              # Data Models
│   └── Message.cs
├── Contexts/            # Database Context
│   └── ChattingDbContext.cs
├── Migrations/          # EF Core Migrations
├── wwwroot/            # Static Files
│   ├── Pages/
│   │   ├── Landing.html
│   │   ├── Index.html
│   │   └── SpecialChat.html
│   ├── css/
│   ├── js/
│   └── lib/
└── Program.cs          # Application Entry Point
```

---

## 🔌 API Endpoints

### SignalR Hub Methods

#### Client → Server

| Method | Parameters | Description |
|--------|-----------|-------------|
| `RegisterUser` | `userName: string` | Register user on connection |
| `Send` | `user: string, message: string` | Send a message to all users |
| `JoinGroup` | `groupName: string, userName: string` | Join a group chat |
| `SendMessageToGroup` | `groupName: string, sender: string, message: string` | Send message to group |
| `NotifyTyping` | `userName: string` | Notify others that user is typing |

#### Server → Client

| Event | Parameters | Description |
|-------|-----------|-------------|
| `ReceiveMessage` | `sender: string, message: string` | Receive a new message |
| `ReceiveMessageFromGroup` | `message: string, sender: string` | Receive group message |
| `NewMemberJoin` | `userName: string, groupName: string` | User joined group |
| `OnlineUsersCount` | `count: number` | Updated online users count |
| `UserTyping` | `userName: string` | User is typing |

---

## 🎨 Customization

### Changing Colors

Edit the CSS variables in any HTML file:

```css
:root {
    --primary: #6366f1;        /* Primary color */
    --primary-dark: #4f46e5;   /* Darker shade */
    --secondary: #ec4899;      /* Secondary color */
    --accent: #14b8a6;         /* Accent color */
    --dark: #0f172a;           /* Background */
    --text: #f1f5f9;           /* Text color */
}
```

### Adding New Features

1. Create a new method in `ChatHub.cs`
2. Add corresponding client-side handler in JavaScript
3. Update the UI as needed

---

## 🤝 Contributing

Contributions are what make the open-source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

---

## 📝 License

Distributed under the MIT License. See `LICENSE` for more information.

---

## 👨‍💻 Developer

<div align="center">

### Ahmed Mohamed Gaber

[![Portfolio](https://img.shields.io/badge/Portfolio-Visit%20Website-6366f1?style=for-the-badge&logo=google-chrome&logoColor=white)](https://codewithahmed.vercel.app/)
[![LinkedIn](https://img.shields.io/badge/LinkedIn-Connect-0077B5?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/ahmed-mohamed-gaber-65bb39238/)
[![GitHub](https://img.shields.io/badge/GitHub-Follow-181717?style=for-the-badge&logo=github&logoColor=white)](https://github.com/AhmedMohamedGaber)

**Full-Stack Developer | ASP.NET Core Specialist | Real-Time Applications Expert**

</div>

---

## 🙏 Acknowledgments

- [ASP.NET Core](https://dotnet.microsoft.com/apps/aspnet) - Web framework
- [SignalR](https://dotnet.microsoft.com/apps/aspnet/signalr) - Real-time communication
- [Google Fonts](https://fonts.google.com/) - Typography
- [Shields.io](https://shields.io/) - Badges

---

## 📞 Support

If you have any questions or need help, feel free to:

- 📧 Email: [Contact through LinkedIn](https://www.linkedin.com/in/ahmed-mohamed-gaber-65bb39238/)
- 🐛 [Open an Issue](https://github.com/AhmedMohamedGaber/ChatWebApp/issues)
- 💬 [Start a Discussion](https://github.com/AhmedMohamedGaber/ChatWebApp/discussions)

---

<div align="center">

**⭐ Star this repo if you find it helpful!**

Made with ❤️ by [Ahmed Mohamed Gaber](https://codewithahmed.vercel.app/)

</div>
