# ChatHub - Real-Time Chat Application

<div align="center">

![ChatHub Logo](https://img.shields.io/badge/ChatHub-Real--Time%20Chat-6366f1?style=for-the-badge&logo=chat&logoColor=white)

[![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-8.0-512BD4?style=flat-square&logo=.net)](https://dotnet.microsoft.com/)
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
<img width="600" src="https://github.com/user-attachments/assets/b9b05a77-2378-4cf2-8c0c-0e7d07eb0d80" />
<p><em>Real-time global chat with premium dark theme and message bubbles</em></p>

### Group Chat (Realms)
<img width="600" src="https://github.com/user-attachments/assets/b00b9c3b-0cee-4751-8317-952816e78c0f" />
<p><em>Discovery system to forge and synchronize with public and private realms</em></p>

---

## ✨ Features

### 🚀 Core Features
- **Real-Time Messaging** - Instant message delivery using SignalR WebSockets
- **Global Broadcast Channel** - Join the main stream immediately upon entry
- **Private & Public Realms** - Create password-protected groups or public communities
- **Discovery System** - Browse available realms or sync via unique handle IDs
- **Identity Isolation** - Messages are strictly contained within their respective realms
- **Online Users Tracking** - Real-time counter for synchronized nodes
- **Smart Reconnection** - Automatic SignalR reconnection logic

### 🎨 User Experience (Premium)
- **Glassmorphism Design** - High-end translucent interfaces and blur effects
- **Dark Theme** - Professional color palette using 'Outfit' typography
- **Responsive Navigation** - Mobile-first design with drawer sidebar and scrim
- **Micro-Animations** - Smooth entry transitions and interactive hover effects
- **Input Optimization** - Auto-focus and Enter-key support across all modules

### 🔧 Technical Features
- **ASP.NET Core 8.0** - High-performance backend framework
- **Entity Framework Core 8.0** - Robust data persistence layer
- **SignalR Hub Architecture** - Bidirectional communication for real-time events
- **Service Layer Pattern** - Decoupled business logic via DI
- **Connection Tracker** - Thread-safe management of online identities

---

## 🛠️ Tech Stack

### Backend
- **Framework**: ASP.NET Core 8.0
- **Real-Time**: SignalR
- **Database**: SQL Server (Entity Framework Core 8.0)
- **Architecture**: Clean Architecture with dedicated Service Layer

### Frontend
- **HTML5** - Semantic layout
- **CSS3** - Modern styling with custom variables and animations
- **JavaScript (ES6+)** - Reactive client-side logic
- **SignalR Client** - Real-time synchronization

### Design
- **Google Fonts** (Outfit) - Premium typography
- **CSS Variables** - Centralized design system
- **Flexbox & CSS Grid** - Responsive orchestration

---

## 📋 Prerequisites

Before you begin, ensure you have the following installed:
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/sql-server/sql-server-downloads) (LocalDB or Express)
- A modern web browser
- [Git](https://git-scm.com/)

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

3. **Initialize Database**
   ```bash
   dotnet ef database update
   ```

4. **Run the application**
   ```bash
   dotnet run
   ```

---

## 🏗️ Project Structure

```
Chat/
├── Hubs/                # SignalR Nexus Hubs
├── Services/            # Business Logic & Group Management
├── Models/              # Data Contracts
├── Contexts/            # EF Core Database Contexts
├── wwwroot/             # Static Assets & Pages
│   ├── Pages/
│   │   ├── Landing.html    # Entry portal
│   │   ├── Index.html      # Global chat
│   │   └── SpecialChat.html # Realm discovery
└── Program.cs          # Application Entry Point
```

---

## 👨‍💻 Developer

<div align="center">

### Ahmed Mohamed Gaber

[![Portfolio](https://img.shields.io/badge/Portfolio-Visit%20Website-6366f1?style=for-the-badge&logo=google-chrome&logoColor=white)](https://codewithahmed.vercel.app/)
[![LinkedIn](https://img.shields.io/badge/LinkedIn-Connect-0077B5?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/ahmed-mohamed-gaber-65bb39238/)
[![GitHub](https://img.shields.io/badge/GitHub-Follow-181717?style=for-the-badge&logo=github&logoColor=white)](https://github.com/AhmedMohamedGaber)

**Full-Stack Developer | ASP.NET Core Specialist**

</div>

---

<div align="center">

**⭐ Star this repo if you find it helpful!**

Made with ❤️ by [Ahmed Mohamed Gaber](https://codewithahmed.vercel.app/)

</div>
