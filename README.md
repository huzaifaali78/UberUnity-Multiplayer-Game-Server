# UberUnity Multiplayer Game Server

## 🎮 Project Overview
A real-time multiplayer game server built with C# .NET that handles multiple game clients with features like damage system, enemy visibility, and chat messaging.

## ✨ Implemented Features

### 🔥 Damage System
- **Health Management**: Players start with 100 HP
- **Damage Application**: Real-time damage calculation when players hit enemies
- **Death System**: Players die when health reaches 0
- **Statistics Tracking**: Automatic kill/death counting
- **Health Broadcasting**: All clients receive health updates

### 👥 Enemy Visibility & Movement
- **Real-time Position Sync**: All player positions synchronized across clients
- **Movement Tracking**: Enemy movements visible to all players
- **Live Updates**: Position updates sent to all clients instantly
- **Multiplayer Support**: Supports multiple players simultaneously

### 💬 Chat System
- **Real-time Messaging**: Players can send chat messages
- **Broadcast Messages**: Messages visible to all players
- **Message History**: Server logs all chat activity

### 🎨 Player Customization
- **Appearance System**: Players can customize their appearance
- **Equipment Tracking**: Holo, head, face, gloves, clothing customization
- **Visual Updates**: Appearance changes broadcast to all clients

## 🛠️ Technical Implementation

### Server Architecture
- **TCP Server**: Handles multiple concurrent connections
- **Thread-safe Operations**: Uses locks for concurrent data access
- **Protocol-based Communication**: Structured message protocol
- **Real-time Updates**: Immediate data synchronization

### Key Components
- `TcpServer.cs` - Main server class handling connections
- `PlayerData.cs` - Player information and state management
- `ByteBuffer.cs` - Network data serialization
- `ServerConfig.cs` - Configuration management

### Network Protocol
- **Protocol 0**: Handshake and player connection
- **Protocol 1**: Position updates and movement
- **Protocol 2**: Game actions (damage, chat, appearance)
  - Type 0: Player joined
  - Type 1: Player left
  - Type 6: Chat message
  - Type 7: Appearance change
  - Type 8: Health update
  - Type 9: Death notification

## 🚀 Getting Started

### Prerequisites
- .NET SDK 6.0 or later
- Unity (for game client)

### Running the Server
1. Navigate to the TcpServer directory
2. Run: `dotnet run`
3. Server starts on port 8001

### Configuration
Edit `config.json` to change server settings:
```json
{
  "port": 8001
}
```

## 📊 Features in Detail

### Damage System Flow
1. Player A shoots Player B
2. Client sends damage data to server
3. Server calculates damage and updates Player B's health
4. Server broadcasts health update to all clients
5. If health ≤ 0, death is processed and statistics updated

### Enemy Visibility Flow
1. Player moves in game
2. Position data sent to server
3. Server updates player position
4. Server broadcasts position to all other players
5. All clients render enemy in new position

## 🔧 Code Highlights

### Health System Implementation
```csharp
// Apply damage to receiving player
receiverPlayer.health -= damageAmount;
if (receiverPlayer.health < 0)
    receiverPlayer.health = 0;

// Broadcast health update
ByteBuffer healthUpdateBuffer = new ByteBuffer();
healthUpdateBuffer.Put((byte)2); // protocol
healthUpdateBuffer.Put((byte)8); // health update
healthUpdateBuffer.Put(receiverId);
healthUpdateBuffer.Put(receiverPlayer.health);
SendToAllClients(healthUpdateBuffer.Trim().Get());
```

### Position Synchronization
```csharp
// Update player position on server
player.x = x; player.y = y; player.z = z;
player.xr = xr; player.yr = yr; player.zr = zr;

// Broadcast to all clients
foreach (var player in playerDatas.Values)
{
    response.Put(player.id);
    response.Put(player.x); response.Put(player.y); response.Put(player.z);
    response.Put(player.xr); response.Put(player.yr); response.Put(player.zr);
}
SendToAllClients(response.Trim().Get());
```

## 🎯 Skills Demonstrated
- **Network Programming**: TCP server implementation
- **Concurrent Programming**: Thread-safe operations
- **Game Development**: Multiplayer game architecture
- **Real-time Systems**: Live data synchronization
- **C# Development**: Object-oriented programming

## 📈 Future Enhancements
- [ ] Player respawn system
- [ ] Weapon damage variations
- [ ] Map-based gameplay
- [ ] Player ranking system
- [ ] Anti-cheat mechanisms

## 👨‍💻 Developer
Created by [Your Name] - showcasing expertise in multiplayer game development and network programming.

---
*This project demonstrates real-time multiplayer game server implementation with comprehensive damage, visibility, and communication systems.*