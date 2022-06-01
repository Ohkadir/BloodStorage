// Load the list - expecting an array of todo_items to be returned
function readTodoItems() {
    fetch('https://localhost:7289/api/Patient')
        // get the JSON content from the response
        .then((response) => {
            if (!response.ok) {
                alert("An error has occurred.  Unable to read the TODO list")
                throw response.status;
            } else return response.json();
        })
        // Add the items to the UL element so that it can  be seen
        // As items is an array, we will the array.map function to through the array and add item to the UL element
        // for display
        //.then(items => items.map(item => addTodoItemToDisplay(item)));
        .then(function (patients) {
            let placeholder = document.querySelector("#data-output");
            let out = "";

            for (let patient of patients) {
                out += `
                                        <tr>
                                          <td>${patient.name} </td>
                                          <td>${patient.postCode} </td>
                                        </tr>
                                      `
            }
            placeholder.innerHTML = out;
        })
}
