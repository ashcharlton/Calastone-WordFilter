# Calastone-WordFilter
## Assumptions

- The spec doesn't mention how to handle punctuation and non-alphanumeric characters, so my first assumption would be to exclude them from the input text and focus on the words.
- The spec also doesn't mention how to handle words containing non-alphanumeric characters such as ' and -. They technically don't add to the letter count and so I will strip them from words as well.

## Approach

- Create an interface for the filters to implement so that they are testable. But they could also be reused elsewhere in the system if needed.
- Unit test each filter to make sure it follows the correct logic.
- Integration test the main program to make sure it outputs a correct string.
- Make the filters flexible so that the program can be extended without the need to refactor a lot of code.