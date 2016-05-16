# Contribution guidelines

## Branching
You should create a new branch for each new feature you want to implement or bug you want to fix. The branch should be named after the issue you're trying to resolve, and include the number of the issue. When you're finished with it, get the code reviewed by opening a pull request to ``master``, and then when this is approved, your added code will be merged into ``master``.

This way all code added can be reviewed properly before being added to ``master``, hopefully reducing the likelihood of problems occurring.

Example: You want to fix issue #9, and so you create a new branch called ``contribution-documentation-#9``. An hour later, you've managed to get it finished and beautiful, so you create a pull request to ``master``. Your teammate reviews and approves your changes, and merges your changes into master. Done! :ok_hand:

## Committing
You should commit your changes reasonably often, you don't have to do it for every line of code but commits like ``added server communication`` don't exactly help much.

##### Language
* Write in present tense, imperative-style, for example ``Fix #1`` instead of ``Fixed #1``.
* Capitalize the first letter.
* Keep the subject line under 69 characters, put further explanations in the body.

##### Emoji
Emojis are used to make the commit-history easier to follow, a bit like lables in the issue tracker. One or more emoji corresponding to a commit's category should be placed **as the first character(s) in a commit subject line**, if the commit falls within one of the following categories:
* :bug: for bugs and bugfixes
* :books: for documentation
* :open_file_folder: for repo management (moving/renaming files etc.)
* :rewind: for reverting changes
* :dart: for changes specific to target devices
* :key: for security related changes

As I'm sure we'll find more uses for emoji, feel free to add new emojis and categories to this list.

## Issues
The issue tracker should be used for most communication. There's many labels to use, everything from ``feature`` and ``bug`` to ``help wanted``. If the issue tracker is used, it will become easy to follow our reasoning behind decisions.
