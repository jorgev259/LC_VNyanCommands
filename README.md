[![Build](https://github.com/jorgev259/LC_VNyanCommands/actions/workflows/main.yml/badge.svg)](https://github.com/jorgev259/LC_VNyanCommands/actions/workflows/main.yml)

<br />
<div align="center">
  <a href="https://github.com/othneildrew/Best-README-Template">
    <img src="images/logo.png" alt="Logo" width="80" height="80">
  </a>

  <h3 align="center">Lethal Company VNyan Commands</h3>

  <p align="center">
    Create interactions in VNyan based on Lethal Company events
    <br />
    <br />
    <a href="https://github.com/jorgev259/LC_VNyanCommands/issues">Report Bug</a>
    ·
    <a href="https://github.com/jorgev259/LC_VNyanCommands/issues">Request Feature</a>
  </p>
</div>

<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#installation">Installation</a>
      <ul>
        <li><a href="#using-a-mod-manager">Preferred Method: Using a mod manager</a></li>
        <li><a href="#manual-method">Manual Method</a></li>
      </ul>
    </li>
    <li><a href="#events">Available Events</a></li>
    <li>
    <a href="#usage">Configuring VNyan</a>
      <ul>
        <li><a href="#configure-premade">Using premade graphs</a></li>
        <li><a href="#configure-manual">Creating graph from scratch</a></li>
      </ul>
    </li>
    <li><a href="#contributing">Advanced Configuration</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgments">Credits</a></li>
    <li><a href="#license">License</a></li>
  </ol>
</details>

## Installation

### Using a mod manager

1. Install [Thunderstore Mod Manager](https://www.overwolf.com/oneapp/Thunderstore-Thunderstore_Mod_Manager)
2. Head to the the mod's [Thunderstore page](https://thunderstore.io/c/lethal-company/p/thechitoteam/SpectatorCameraConfig/)
3. Press "Install with Mod Manager"
4. Follow instructions

### Manual method

1. Install [BepInEx 5](https://docs.bepinex.dev/articles/user_guide/installation/index.html)
2. Download `LC_VNyanCommands-vX_X_X.zip` from the [Release Page](https://github.com/jorgev259/LC_VNyanCommands/releases/tag/v1.0.0) or [Thunderstore](https://thunderstore.io/c/lethal-company/p/thechitoteam/SpectatorCameraConfig/)
3. Copy the `BepInEx` folder inside the zip file and paste into your Lethal Company game folder

## Available Events

### Player Death

Triggers on player death.
<br />
Available causes:

- Unknown
- Bludgeoning
- Gravity
- Blast
- Strangulation
- Suffocation
- Mauling
- Gunshots
- Crushing
- Drowning
- Abandoned
- Electrocution
- Kicking

Events:

- `LC_Death` (Triggers on player death no matter the cause)
- `LC_Death_{Cause}` (Triggers on death by an specific cause). Example: `LC_Death_Electrocution`
