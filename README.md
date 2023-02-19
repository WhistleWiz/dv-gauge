﻿[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![Apache 2.0 License][license-shield]][license-url]




<!-- PROJECT LOGO -->
<div align="center">
  <h1>Gauge</h1>
  <p>
    An experimental <a href="https://store.steampowered.com/app/588030">Derail Valley</a> mod rebuilding the valley in 3ft narrow gauge!
    <br />
    <br />
    <a href="https://github.com/Insprill/dv-gauge/issues">Report Bug</a>
    ·
    <a href="https://github.com/Insprill/dv-gauge/issues">Request Feature</a>
  </p>
</div>




<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li><a href="#about-the-project">About The Project</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#building">Building</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
  </ol>
</details>




<!-- ABOUT THE PROJECT -->

## About The Project

Gauge is an experimental Derail Valley mod to allow changing the track gauge.
Currently, it only supports 3ft narrow gauge.




<!-- ROADMAP -->

## Roadmap

A rough roadmap of things that are done, and things that need to be done.

- [ ] Rails
  - [x] Regular splines
    - [x] Rails
    - [x] Anchors
    - [x] Sleepers
    - [x] Ballast
  - [x] Switches
  - [x] Turn Tables
  - [ ] Roundhouse tracks
  - [x] End-of-track buffers
  - [ ] Service station markers
- [x] Rolling stock
  - [x] Cars
  - [x] DE2
  - [x] DE6
  - [x] SH282




<!-- BUILDING -->

## Building

To build Gauge, you'll need to create a new [`Directory.Build.targets`](https://learn.microsoft.com/en-us/visualstudio/msbuild/customize-your-build?view=vs-2022) file to specify your reference paths. 
This file should be located in the root of the project, next to this README.

Here's an example file you can use as a template.
Replace the provided paths with the paths to your Derail Valley installation directory.
Make sure to include the semicolons between each of the paths, but not after the last one!
Note that shortcuts like `%ProgramFiles%` *cannot* be used.
```xml
<Project>
    <PropertyGroup>
        <ReferencePath>
            C:\Program Files (x86)\Steam\steamapps\common\Derail Valley\DerailValley_Data\Managed\;
            C:\Program Files (x86)\Steam\steamapps\common\Derail Valley\DerailValley_Data\Managed\UnityModManager\;
            C:\Program Files (x86)\Steam\steamapps\common\Derail Valley\Mods\DVCustomCarLoader\
        </ReferencePath>
        <AssemblySearchPaths>$(AssemblySearchPaths);$(ReferencePath);</AssemblySearchPaths>
    </PropertyGroup>
</Project>
```

To test your changes, `Gauge.dll` will need to be copied into the mod's install directory (e.g. `...Derail Valley/Mods/Gauge`).
You can find it in `bin/Debug` or `bin/Release` depending on the selected build configuration.

<details>
<summary>Linux</summary>

To build under Linux, you'll need to adjust the paths and add the path to your UnityModManager installation for Harmony.

Here's an example file assuming Steam and Derail Valley are both installed in their default paths, and UnityModManger is installed next to Steam.
```xml
<Project>
    <PropertyGroup>
        <ReferencePath>
            /home/username/.local/share/Steam/steamapps/common/Derail Valley/DerailValley_Data/Managed/;
            /home/username/.local/share/Steam/steamapps/common/Derail Valley/DerailValley_Data/Managed/;
            /home/username/.local/share/Steam/steamapps/common/Derail Valley/Mods/DVCustomCarLoader/;
            /home/username/.local/share/UnityModManager/
        </ReferencePath>
        <AssemblySearchPaths>$(AssemblySearchPaths);$(ReferencePath);</AssemblySearchPaths>
    </PropertyGroup>
</Project>
```
</details>



<!-- CONTRIBUTING -->

## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create.  
Any contributions you make are **greatly appreciated**!  
If you're new to contributing to open-source projects, you can follow [this][contributing-quickstart-url] guide.




<!-- LICENSE -->

## License

Distributed under the Apache 2.0 license.  
See [LICENSE][license-url] for more information.




<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->

[contributors-shield]: https://img.shields.io/github/contributors/Insprill/dv-gauge.svg?style=for-the-badge
[contributors-url]: https://github.com/Insprill/dv-gauge/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/Insprill/dv-gauge.svg?style=for-the-badge
[forks-url]: https://github.com/Insprill/dv-gauge/network/members
[stars-shield]: https://img.shields.io/github/stars/Insprill/dv-gauge.svg?style=for-the-badge
[stars-url]: https://github.com/Insprill/dv-gauge/stargazers
[issues-shield]: https://img.shields.io/github/issues/Insprill/dv-gauge.svg?style=for-the-badge
[issues-url]: https://github.com/Insprill/dv-gauge/issues
[license-shield]: https://img.shields.io/github/license/Insprill/dv-gauge.svg?style=for-the-badge
[license-url]: https://github.com/Insprill/dv-gauge/blob/master/LICENSE
[contributing-quickstart-url]: https://docs.github.com/en/get-started/quickstart/contributing-to-projects
