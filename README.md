# Git Workflow Overview
This document outlines the Git workflow used in this project, detailing the strategies for branching, naming conventions, commit messages, and pull request processes. By establishing a clear workflow, we aim to enhance collaboration, maintain consistency, and streamline development efforts among team members. This guideline serves as a comprehensive reference to ensure that contributions are organized, easily understandable, and efficient throughout the project's lifecycle.

<br>

## Git Branching Strategy

This document section outlines the Git branching strategy used in this project. It provides a structured yet flexible workflow for feature development, collaboration, and experimentation.

### Main Branches

#### `main`
- This branch contains the **stable, production-ready** code.
- Code here is fully tested and can be deployed at any time.
- Only changes that have been thoroughly reviewed and tested in `develop` should be merged into `main`.

#### `develop`
- This branch is used for **active development** and serves as an integration point for completed features.
- New features and bug fixes should be merged into `develop` after testing and code review.
- This branch is the basis for the next release.

#### `[name]/[type]/[detail]`
- This branch is used for experimental and personal exploration. 
- This branch allows developers to work on features or ideas without affecting the core project or interfering with others.
- **Important**: Code in the Playground branch is **experimental** and should not be merged directly into `develop` without proper review. If an experiment proves successful, merge it into a feature branch or `develop` after testing.

<br>

## Naming Convention

This section outlines the naming conventions used in this project to maintain clarity and consistency across all branches, commits, and pull requests to ensure that all developers' contributions are easily understandable by others in the team, making collaboration smoother and more efficient.

### Branch Names
`<name>/<type>/<detail>`

- **Format**: 
    - `name` refers to the developer’s name or username (e.g., `john`, `susan`).
    - `type` refers to the nature of the changes being made (e.g., `feat`, `refactor`, `fix`).
    - `detail` is a short, descriptive name for the feature or task (e.g., `login-page`, `user-auth`).

- **Types**: 
    - `feat` — new feature for the user
    - `fix` — bug fix for the user
    - `chore` — something to do with small task (import package, rename files, etc)
    - `revamp` — something to do with changes to already available features (more to edit not adding something new to feature)
    - `refactor` — refactoring production code
    - `test` — adding missing tests, refactoring tests

- **Examples**:
    - `john/docs/setup-instructions`
    - `john-smith/feat/user-authentication`

### Commit Messages
`<type>(<optional scope>): <description>`

- **Format**: 
    - `type` refers to the nature of the changes being made (e.g., `feat`, `refactor`, `fix`).
    - `optional scope`: (Optional) This is a brief identifier that indicates the specific part of the codebase that the changes affect (e.g., `api`, `button`).
    - `description`: A concise summary of the changes made. (e.g., `add login page`, `fix logout button`).

- **Types**: 
    - `feat` — new feature for the user
    - `fix` — bug fix for the user
    - `docs` — documentation changes
    - `style` — formatting, missing semi colons, etc.
    - `refactor` — refactoring production code
    - `test` — adding missing tests, refactoring tests

- **Examples**:
    - `feat: add login page`
    - `fix(api): resolve 404 error on user fetch`
    - `docs: update README with setup instructions`

### Pull Requests (Title)
`<type>(<optional scope>): <brief-description>`

- **Format**: 
    - `type`: Indicates the nature of the changes being proposed (e.g., `feat`, `fix`, `docs`).
    - `optional scope`: (Optional) A brief identifier that indicates the specific part of the codebase that the changes affect (e.g., `api`, `button`).
    - `brief-description`: A concise summary of what the pull request addresses or implements (e.g., `add user authentication`, `resolve 404 error`).

- **Types**: 
    - `feat` — new feature for the user
    - `fix` — bug fix for the user
    - `docs` — documentation changes
    - `style` — formatting, missing semi colons, etc.
    - `refactor` — refactoring production code
    - `test` — adding missing tests, refactoring tests

- **Examples**:
    - `feat: add user authentication`
    - `fix(api): resolve 404 error on user fetch`
    - `docs: update README with setup instructions`

### Pull Requests (Description)
```
## Description
A description of the changes made.

## Changes Made
* Bullet point list of changes made

## Screenshots (if applicable)
Include screenshots of the changes in action, if applicable. (delete if NOT applicable)
```

- **Format**:
    - `## Description`: A description of the changes made in the pull request.
    
    - `## Changes Made`: A bullet point list of changes included in this pull request.
    
    - `## Screenshots (if applicable)`: Include any relevant screenshots demonstrating the changes.

- **Example**:
    ```
    ## Description
    Added user authentication feature to allow users to securely log in and access their accounts.

    ## Changes Made
    * Created login and registration forms
    * Integrated authentication API
    * Added JWT token handling
    * Updated navigation to reflect authentication state
    ```
