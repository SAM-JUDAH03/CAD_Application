# CAD Application

A desktop CAD (Computer-Aided Design) application built with **C# WPF** (.NET Framework 4.7.2), following the **MVVM** architectural pattern.

---

## 📋 Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Project Structure](#project-structure)
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [Dependencies](#dependencies)
- [Contributing](#contributing)

---

## Overview

CAD Application is a Windows desktop application that provides drawing and design tools. It leverages WPF's powerful rendering capabilities along with the Xceed Extended WPF Toolkit for enhanced UI components.

---

## Features

- 2D drawing and design canvas
- Drawing state management
- Geometry helper utilities
- Serialization support for saving/loading designs
- Brush and style customization

---

## Project Structure

```
CAD_Application/
├── CAD_Application.slnx          # Solution file
└── CAD_Application/
    ├── Assets/                   # Application images and icons
    ├── Helpers/
    │   ├── BrushHelper.cs        # Brush/color utilities
    │   ├── GeometryHelper.cs     # Geometry calculation utilities
    │   └── SerializationHelper.cs# Save/load helpers
    ├── Models/
    │   └── DrawingState.cs       # Drawing state data model
    ├── ViewModels/
    │   └── MainViewModel.cs      # Main MVVM ViewModel
    ├── Views/
    │   ├── MainWindow.xaml       # Main application window (UI)
    │   └── MainWindow.xaml.cs    # Code-behind
    ├── Properties/               # Assembly info and resources
    ├── App.xaml                  # Application entry point (UI)
    ├── App.xaml.cs               # Application entry point (code)
    ├── App.config                # Application configuration
    ├── packages.config           # NuGet package references
    └── CAD_Application.csproj    # Project file
```

---

## Prerequisites

- **Windows OS** (WPF is Windows-only)
- **Visual Studio 2022** (or later) with the **.NET desktop development** workload
- **.NET Framework 4.7.2** (included in Visual Studio)
- **NuGet Package Manager** (built into Visual Studio)

---

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/<your-username>/CAD_Application.git
cd CAD_Application
```

### 2. Restore NuGet packages

Open the solution in Visual Studio. It will automatically prompt to restore packages. Or run:

```bash
nuget restore CAD_Application.slnx
```

### 3. Build and run

- Open `CAD_Application.slnx` in Visual Studio
- Press **F5** to build and launch in Debug mode, or **Ctrl+F5** to run without debugging

---

## Dependencies

| Package | Version | Purpose |
|---|---|---|
| [Extended.Wpf.Toolkit](https://github.com/xceedsoftware/wpftoolkit) | 5.0.0 | Advanced WPF UI controls (AvalonDock, etc.) |

> **Note:** NuGet packages are NOT committed to the repository. They are restored automatically via `packages.config`.

---

## Contributing

1. Fork the repository
2. Create a feature branch: `git checkout -b feature/your-feature-name`
3. Commit your changes: `git commit -m "feat: add your feature description"`
4. Push to the branch: `git push origin feature/your-feature-name`
5. Open a Pull Request

---

## License

This project is licensed under the [MIT License](LICENSE).
