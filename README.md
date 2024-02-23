[![Build](https://github.com/jorgev259/LC_VNyanCommands/actions/workflows/main.yml/badge.svg)](https://github.com/jorgev259/LC_VNyanCommands/actions/workflows/main.yml)

<br />
<div align="center">
  <a href="https://github.com/jorgev259/LC_VNyanCommands">
    <img src="https://github.com/jorgev259/LC_VNyanCommands/raw/main/Assets/icon.png" alt="Logo" width="80" height="80">
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
    <li>
      <a href="#events">Available Events</a>
      <ul>
        <li><a href="#player-death">Player Death</a></li>
        <li><a href="#walkie-talkie">Walkie Talkie</a></li>
      </ul>
    </li>
    <li>
    <a>Configuring VNyan</a>
      <ul>
        <li><a>Using premade graphs</a></li>
        <li><a>Creating graph from scratch</a></li>
      </ul>
    </li>
    <li><a>Advanced Configuration</a></li>
    <li><a>Contact</a></li>
    <li><a href="#credits">Credits</a></li>
    <li><a>License</a></li>
  </ol>
</details>

## Installation

### Using a mod manager

1. Install [Thunderstore Mod Manager](https://www.overwolf.com/oneapp/Thunderstore-Thunderstore_Mod_Manager)
2. Head to the the mod's [Thunderstore page](https://thunderstore.io/c/lethal-company/p/thechitoteam/VNyanCommands/)
3. Press "Install with Mod Manager"
4. Follow instructions

### Manual method

1. Install [BepInEx 5](https://docs.bepinex.dev/articles/user_guide/installation/index.html)
2. Download `LC_VNyanCommands-vX_X_X.zip` from the [Release Page](https://github.com/jorgev259/LC_VNyanCommands/releases/) or [Thunderstore](https://thunderstore.io/c/lethal-company/p/thechitoteam/VNyanCommands/)
3. Copy the `BepInEx` folder inside the zip file and paste into your Lethal Company game folder

## Available Events

### Player Death

Triggers on player death.
<br />
<br />
Events:

- `LC_Death` (Triggers on player death no matter the cause)
- `LC_Death_{Cause}` (Triggers on death by an specific cause). Example: `LC_Death_Electrocution`

Available causes:

- `Unknown` (Ghost Girl/Hygrodere/Baboon Hawk)
- `Bludgeoning` (Shovel)
- `Gravity` (Falling)
- `Blast` (Landmine)
- `Strangulation` (Bracken)
- `Suffocation` (Snare Flea or Mask)
- `Mauling` (Eyeless Dog, etc)
- `Gunshots` (Turret/Nutcracker Shotgun)
- `Crushing` (Dropship/Extension Ladder)
- `Drowning` (Lake)
- `Abandoned` (Left behind)
- `Electrocution` (Circuit Bees/Lightning)
- `Kicking` (Nutcracker)
- `Spring` (Coilhead)
- `Cocoon` (Spider)
- `Slime` (Hygrodere)
- `Possession` (Masked)
- `Decapitation` (Little Girl)

<br />

### Walkie Talkie

Triggers when holding Walkie Talkie and when speaking into it
<br />
<br />
Events:

- `LC_WalkieTalkie_Hold_On`
- `LC_WalkieTalkie_Hold_Off`
- `LC_WalkieTalkie_Power_On`
- `LC_WalkieTalkie_Power_Off`
- `LC_WalkieTalkie_Speak_On`
- `LC_WalkieTalkie_Speak_Off`

<br />

### Player Damage

Triggers when the local player receives damage
<br />
<br />
Events:

- `LC_PlayerDamage`
- `LC_PlayerDamage_Shovel`

## Credits

- Advanced deaths referenced from [Coroner Mod](https://github.com/EliteMasterEric/Coroner)
