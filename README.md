# **AssetRepo**

## *Project Objective*

This project was conceived as a foundation for a website designed for artists and developers to collaborate on video game creation without the need for explicit partnership. My personal goal was to discover algorithms for routing complex page interactions and implement the basic routing functionality I would want in the publically-released product.

## *Viewing Project*

To run the web application, clone or download the repo and open the solution in your particular version of Visual Studio. **Make sure to build the project first, then open the NuGet console and run `Update-Database` prior to starting the application.** Start at the root, and, before adding an asset or a project, **add at least one contributor** (else there will be none to select on the add page and the entry will not validate).

## *Notes on Functionality*

The only model with full CRUD functionality implemented is `Asset`. However, `Contributor.cs` has CRU functionality (deletion was omitted as I didn't want to anonymize contributions after the fact and user account validation is not implemented), and `Project` has CRU functionality plus the "soft delete" inactivation/reactivation functionality (which prevents cascade-deletion or orphaning of assets and allows users to reactivate projects that regain promise later). `AssetType`, `AssetSubtype`, `AssetTypeSubtypePairing`, and `ProjectCategory` are not intended to be altered by the user and are thus relegated to "look-up" functionality.

### Thanks for reviewing my site! Please let me know where I can most improve.

###### Website &copy; Colton Atticus Gurley
