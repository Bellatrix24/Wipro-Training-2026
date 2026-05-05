# Day 11: Unit Testing and TDD Implementation

Today I learned about the importance of testing in software development. It's not just about finding bugs at the end, but about building quality into the code from the start!

## 1. Why We Test?
Testing is crucial for a few big reasons:
- **Detect Bugs Early**: Finding a mistake while writing code is much cheaper than finding it after the app is launched.
- **Ensure Quality**: It gives us confidence that our logic actually works as expected.
- **Prevent Regression**: When we add new features, tests help us make sure we didn't accidentally break old ones.

## 2. Unit Testing vs. Integration Testing
- **Unit Testing**: We test small, individual pieces (like a single method) in isolation.
- **Integration Testing**: we test how multiple parts of the system work together (like the database and the UI).

## 3. The AAA Pattern
This is the standard way to structure a test case:
1. **Arrange**: Prepare the data and objects needed for the test.
2. **Act**: Execute the method or action we want to test.
3. **Assert**: Verify that the result matches what we expected.

## 4. TDD Workflow (Test Driven Development)
The "Red-Green-Refactor" cycle:
- **Red**: Write a test that fails (because the code doesn't exist yet).
- **Green**: Write just enough code to make the test pass.
- **Refactor**: Clean up the code while keeping the test passing.
