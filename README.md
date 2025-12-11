# 🌀 a-MAZE-ing 3D  
A physics-based 3D maze game where you tilt the entire board to roll a ball toward the goal!  
Each level increases difficulty, tracks your progress, and challenges your precision and control.

---

## 🎮 Game Overview

**a-MAZE-ing 3D** is a Unity project where the player controls the maze itself rather than moving the ball directly.  
Tilt the maze using your mouse or keyboard, let gravity do the work, and guide the ball safely to the finish point.

- Smooth tilt-based movement  
- Realistic rolling physics  
- Increasing difficulty  
- Persistent background music  
- Automatic scene progression  
- High score tracking (optional)

---

## 🧩 Core Features

### 🌀 Tilt-to-Move Controls
The maze uses a physics-based tilting system:
- Use keyboard → maze tilts smoothly  
- Ball rolls naturally due to gravity  
- Rigidbodies + colliders ensure proper physics behavior  

### 🌍 Ball Physics & Respawn System
- Ball spawns at a designated **RespawnPoint** in every maze scene  
- Rigidbody handles gravity, rolling, and wall collisions  
- Prevents floating or jumping  
- When ball reaches **FinishPoint**, next level loads automatically  

### 🔊 Persistent Audio Manager
- Background music plays continuously across scenes  
- Managed through a `DontDestroyOnLoad` root object  
- Single AudioSource for adjustable volume  

### 🗺️ Multi-Scene Level Progression
- A dedicated **GameManager** maintains:
  - Current level  
  - Randomized scene progression  
  - Entry from Start Menu  
- Each maze is its own Unity scene  
- Touch finish → load next scene → respawn ball  

---

## 🚀 How to Play

### 1️⃣ Start the Game
- Open the project in Unity  
- Load the **Welcome** scene  
- Press **Start**  
- Music and managers initialize automatically  

### 2️⃣ Tilt the Board
Control the maze via: 
- **WASD / Arrow keys**  

The maze rotates slightly, causing the ball to roll.

### 3️⃣ Reach the Finish
- Navigate the maze  
- Touch the **FinishPoint**  
- Scene changes automatically  
- Ball respawns in the new maze  

### 4️⃣ Continue Progressing
Each level becomes more challenging.  
Optional: track high scores and level count.

---

## ⚙️ Project Structure

```
Assets/
 ├── Scenes/
 │    ├── Welcome.unity
 │    ├── Maze_1.unity
 │    ├── Maze_3.unity
 │    ├── C.unity
 │    └── ...
 ├── Scripts/
 │    ├── Ball.cs
 │    ├── BoardController.cs
 │    ├── GameManager.cs
 │
 ├── Prefabs/
 │    ├── Ball.prefab
 │    
 └── Materials / Models / Art
```

---

## 🔧 Developer Setup

1. Clone/download the repository  
2. Open **Unity Hub**  
3. Select **Open Project**  
4. Load this project folder  
5. Open **Welcome** scene  
6. Press ▶ **Start**  

---

## 🛠️ Team Workflow Summary

- Each developer produces one maze level  
- All levels added to Build Settings  
- Assets, art, and code shared via GitHub  
- Team merges updates regularly  
- New levels plug in easily due to the modular design  

---

## 👥 Credits

| Name | Role |
|------|------|
| **Hooman Manesh** | Developer |
| **Nathan Morales** | Designer |
| **Chris Lepe Tenorio** | Programmer |
| **Cameron Croom** | Artist |

---
