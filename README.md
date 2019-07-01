# Description

The default Edit.WordNext command moves the cursor only to the beginning of the next word.

This extension provides the **Edit.WordNextEnd** command, which moves the cursor to the end of the current word first, and , if the command is triggered again, to the beginning of the next word afterwards. In other words, an additional text anchor is added to this type of movement command.

Analogously,**Edit.WordPreviousEnd** is provided for the opposite direction, and **Edit.WordPreviousEndExtend** and **Edit.WordNextEndExtend** are provided for extending selections.

### Example

    *The*      *Stars*     *illustrate*      *where* *the* *cursor*        *is*     *placed*

# Usage

After installing the vsix, the commands can be accessed via

    Tools > Options > Environment > Keyboard

It is suggested to overwrite the Edit.Word* keys, i.e., Ctrl+Right Arrow etc.

# Comments?

I am no C# coder, so if you have any suggestions for improvement, feel free to submit a pull request.
