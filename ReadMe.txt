Problem:
Partial view requires a .js file to be included in the page. But the partial has no context of the @section Script on the
main layout page. Need a way to ensure all js files are only referenced in the designated Script section of the page.

Solutions:
You need 2 Html helper methods. RequireScript and IncludeRequiredScripts.
The RequireScript method will ensure that only 1 copy of the required .js file is included incase several partials are
using the same reference. See ViewCode.txt to see where those method need to be called.