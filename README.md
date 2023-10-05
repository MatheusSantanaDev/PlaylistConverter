# PlaylistConverter

**Teste Tecnico da empresa Agile Content**

"
In the Microsoft Visual Studio IDE, there is a feature that allows us to select a list of unit tests and save them in a file with the ".playlist" extension.
The content of this file consists of a proprietary XML format, containing the selected tests, which can be imported again by Visual Studio.

In order to optimize the execution flow of tests and enable their execution by other tools, it will be necessary to convert this playlist file to a new format.

We provide a sample Visual Studio playlist file at the following URL:

>https://gvp-qa.s3.amazonaws.com/examples/unit_tests.playlist

From the file in the link above, it is expected to generate a text file with content identical to the file in the following link:
>https://gvp-qa.s3.amazonaws.com/examples/unit_tests.txt

In this new format, each line of the text file should contain the name of the method corresponding to each unit test present in the playlist.
Implement a DotNet solution that receives the path to the Visual Studio playlist file and the path to the generated text file as parameters.

Example program invocation:

>PlaylistConverter.exe "c:\tests.playlist" "c:\tests.txt"

It is expected that the code adheres to best development practices, with well-defined routines and responsibilities, in order to make maintenance and potential code reuse easier.
"
