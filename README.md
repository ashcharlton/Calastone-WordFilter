# Calastone-WordFilter
## Assumptions

- The spec doesn't mention how to handle punctuation and non-alphanumeric characters, so my first assumption would be to exclude them from the input text and focus on the words.
- Words that contain inner punctuation such as - and ' should have this removed but printed like so. I will sanitise the word for checking but print out the word as is. e.g. Can't will be checked against cant but printed as can't.
- Words that contain - are counted as 1 word, but this will be stripped when checking in the filter.

## Approach

- Create an interface for the filters to implement so that they are testable. But they could also be reused elsewhere in the system if needed.
- Unit test each filter to make sure it follows the correct logic.
- Integration test the main program to make sure it outputs a correct string.
- Make the filters flexible so that the program can be extended without the need to refactor a lot of code.

## Running the application

Hit the run button to run the application. I have added the input text in Input.txt that is copied to the build folder.

## Filters
- I have made the filters configurable such as passing in the character to check or the min length of a word so that they can be used elsewhere without having to duplicate code.
- They all implement the same interfacce but have different constructors to make them flexible.
- They are registered in the program.cs file to satisfy the test spec of containg a t and having less than 3 characters.
- The order in which they are registered is important. I feel the filters to check if the word contains a certain letter and is less than 3 characters are cheap in process. Where as the check for the centre vowels is more expensive. So they are registered so that the text contains and length check are done first. Then you only have to run the most expensive filter on fewer words.


## Tests
- I have added quite a few test cases to cover edge cases.
- I also integration tested the TextFilterApp so that the logic for the filters isn't mocked and more accuratley tests their logic. Essentially writing an end-to-end test as we give it an input and test the output of the whole application.
- 