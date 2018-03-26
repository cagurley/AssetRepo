# **AssetRepo**

## *Project Objective*

This project was conceived as a foundation for a website designed for artists and developers to collaborate on video game creation without the need for explicit partnership. My personal goal was to discover algorithms for routing complex page interactions and implement the basic routing functionality I would want in the publically-released product.

## *Viewing Project*

To run the web application, clone or download the repo and run in your particular version of Visual Studio. **Make sure to run `Update-Database` from the NuGet console before running.** Navigation largely follows conventions and should be intuitive where it doesn't. Start at the root and play around!

## *Notes on Functionality*

The only model with full CRUD functionality implemented is `Asset`; however, both `Project` and `Contributor.cs` have CRU functionality (deletion was omitted mostly to prevent cascade deletion or orphaning of assets). `AssetType`, `AssetSubtype`, `AssetTypeSubtypePairing`, and `ProjectCategory` are not intended to be altered by the user and are thus relegated to "look-up" functionality.

### Thanks for reviewing my site! Please let me know where I can most improve.

###### Website &copy; Colton Atticus Gurley
