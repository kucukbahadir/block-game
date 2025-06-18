Eduana integration package read me:

This package contains the system that allow us to talk to the Eduana web app. By doing this we can get keywords from a students so they can practice them inside a game. This system can fetch keywords and send the result. To make this system work you need to set up a couple things inside Unity.

===============================

Downloading the Newtonsoft package:

This is a package that make it easier to read a JSON file. In the system we use this package to deconstruct the JSON file.

- Step 1
    Open the package manager inside Unity

- Step 2
    Click on the plus icon on the left top corner of the package manager

- Step 3
    Click on the option to 'Install package from git hub URL' and use https://github.com/jilleJr/Newtonsoft.Json-for-Unity.git#upm to download the package

===============================

Change the EduanaManager scripts execution order:

To make sure this script always get called before everything you need to let Unity know to call this script before the normal execute times.

- Step 1
    Go to the project settings menu

- Step 2
    Go to the tab "Script execution order"

- Step 3
    Drag the EduanaManager script above the default time block