[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]




<!-- PROJECT TITLE -->
<div align="center">
	<h1>Unity Mod Manager Mod Template</h1>
	<p>
		A template for creating <a href="http://www.derailvalley.com/">Derail Valley</a> mods that load via <a href="https://www.nexusmods.com/site/mods/21">Unity Mod Manager</a>.
		<br />
		<br />
		<a href="https://github.com/derail-valley-modding/template-umm/issues">Report Bug</a>
		·
		<a href="https://github.com/derail-valley-modding/template-umm/issues">Request Feature</a>
	</p>
</div>




<!-- TABLE OF CONTENTS -->
<details>
	<summary>Table of Contents</summary>
	<ol>
		<li><a href="#about-the-project">About The Project</a></li>
		<li><a href="#building">Building</a></li>
		<li><a href="#packaging">Packaging</a></li>
		<li><a href="#license">License</a></li>
	</ol>
</details>




<!-- ABOUT THE PROJECT -->

## About The Project

This is a template for Derail Valley mods that load via the Unity Mod Manager mod loader.  

## Initial setup


### Get all files and names in place

Using a shell of your choice (E.g. powershell), open a session (E.g. powershell window) at the `_SETUP_` directory.

Ensure `dotnet` is installed. Just type `dotnet` in your shell to test that. If it isn't, then you need to install that first.

Execute a `dotnet` command as follows to setup the project for you:

```
dotnet build -c SETUP_ENV -p MOD_NAME=ModNameOfYourChoice -p MOD_AUTHOR=TheNameYouAreKnownFor
```
E.g.
```
dotnet build -c SETUP_ENV -p MOD_NAME=UmmmmExample -p MOD_AUTHOR=fauxnik
```

If that execution is a success, feel free to delete the `_SETUP_` directory, the initial setup is done.

### Finished last touches

#### Edit `info.json`,

Fill in the `Repository` field and either fill in or delete the `Homepage` field.

The `Repository` field is what allows automatic updates to work correctly.

#### Make own build configuration using `Directory.Build.targets`

Move `Directory.Build.targets.template` inside your project dirctory to [`Directory.Build.targets`][references-url].

Edit [`Directory.Build.targets`][references-url] according to the instructions at the top.


When editing `DerailValleyPath` in your [`Directory.Build.targets`][references-url] file, you will need to replace the reference path with the corresponding folder/directory on your system. Also note that any shortcuts you might use in file explorer—such as %ProgramFiles%—won't be expanded in these paths. If you know what they are, you can use symlinks or junctions if you prefer to use relative paths, otherwise, use absolute paths.  
Here's two examples of valid absolute paths for `DerailValleyPath` including the XML tags.

Windows: `<DerailValleyPath>C:\Program Files (x86)\Steam\steamapps\common\Derail Valley</DerailValleyPath>`

Linux: `<DerailValleyPath>/home/username/.steam/steamapps/common/Derail Valley</DerailValleyPath>`

You also must set your `CodeRepositoryUrl` to the URL of the repository you are using. A format to match github's is already provided for you where you only need to replace `OWNER` and `REPOSITORY`.

If you are not using github you might need to change `DownloadUrl` in the file `building/Repository.json.props`

For more details, see: https://wiki.nexusmods.com/index.php/How_to_make_updates_(UMM)


<!-- BUILDING -->

## Building


### So, how to build?

Building the project is done by running `dotnet build` and specifying the build configuration you want. Here's 2 examples:

- `dotnet build -c Debug` will do a Debug build.
- `dotnet build -c Release` will do a Release build.


### Build configurations?

There are many configurations at your disposal to do a build. A few are expected to be used much more commonly than others.
The most common should be:

- `Reload`
- `DebugInstall`
- `ReleaseInstall`

There's also:
- `Debug`
- `Release`


The first 3, are configurations which copy the new version to your mods directory in Derail Valley making it ready to use.

`Debug` and `Release` and `ReleaseInstall` also produce an output archive which you can use to release a new version or to send to someone with debug activated.

`DebugInstall` is meant for the first time you make a build or if you want to make a build and restart Derail Valley.

### What is `Reload` configuration for?

`Reload` is about the same as `DebugInstall` except the dll is slightly modified according to [Umm's manual on how to reload at runtime](https://wiki.nexusmods.com/index.php/How_to_reload_mod_at_runtime_(UMM)) so the dll has a good chance to correctly reload at runtime, allowing you to make changes and apply them immediately without having to restart Derail Valley.



### Line Endings Setup

It's recommended to use Git's [autocrlf mode][autocrlf-url] on Windows. Activate this by running `git config --global core.autocrlf true`.




<!-- PACKAGING -->

## Packaging

To package a build for distribution, just run `dotnet build -c Release` in the root of the project it will create a .zip file ready for distribution in the dist directory.

It generates a `repository.json` file (see above about it) and then packages all built `.dll`, `LICENSE` and `info.json` files into a `.zip` archive ready for distribution. That file is stored inside the dist directory.

Note: Don't forget to commit and push the generated `repository.json` file.


### Alternate way

If you prefer using an external script, you may package a build for distribution by running the `package.ps1` PowerShell script in the root of the project. If no parameters are supplied, it will create a .zip file ready for distribution in the dist directory. A post build event is configured to run this automatically after each successful Release build.

Linux: `pwsh ./package.ps1`
Windows: `powershell -executionpolicy bypass .\package.ps1`


### Parameters

Some parameters are available for the packaging script.

#### -NoArchive

Leave the package contents uncompressed in the output directory.

#### -OutputDirectory

Specify a different output directory.
For instance, this can be used in conjunction with `-NoArchive` to copy the mod files into your Derail Valley installation directory.




<!-- LICENSE -->

## License

Source code is distributed under the MIT license.
See [LICENSE][license-url] for more information.




<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->

[contributors-shield]: https://img.shields.io/github/contributors/derail-valley-modding/template-umm.svg?style=for-the-badge
[contributors-url]: https://github.com/derail-valley-modding/template-umm/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/derail-valley-modding/template-umm.svg?style=for-the-badge
[forks-url]: https://github.com/derail-valley-modding/template-umm/network/members
[stars-shield]: https://img.shields.io/github/stars/derail-valley-modding/template-umm.svg?style=for-the-badge
[stars-url]: https://github.com/derail-valley-modding/template-umm/stargazers
[issues-shield]: https://img.shields.io/github/issues/derail-valley-modding/template-umm.svg?style=for-the-badge
[issues-url]: https://github.com/derail-valley-modding/template-umm/issues
[license-shield]: https://img.shields.io/github/license/derail-valley-modding/template-umm.svg?style=for-the-badge
[license-url]: https://github.com/derail-valley-modding/template-umm/blob/main/LICENSE
[references-url]: https://learn.microsoft.com/en-us/visualstudio/msbuild/customize-your-build?view=vs-2022
[autocrlf-url]: https://www.git-scm.com/book/en/v2/Customizing-Git-Git-Configuration#_formatting_and_whitespace
