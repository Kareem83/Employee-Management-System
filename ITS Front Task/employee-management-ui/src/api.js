const API_URL = "https://localhost:7209/api/employees";


export async function getEmployees()
{
    const response = await fetch(API_URL);

    const data = await response.json();

    return data;
}


export async function deleteEmployee(id)
{
    await fetch(
        `${API_URL}/${id}`, //https://localhost:7209/api/employees/ال id
        {
            method: "DELETE"
        }
    );
}



export async function addEmployee(employee)
{
    const response = await fetch( //we use await cause the response take time until give me a response and in this time it gives me a promise so i use await to wait until converting the state from promise to real data
        API_URL,
        {
            method: "POST",

            headers:
            {
                "Content-Type": "application/json"
            },

            body: JSON.stringify(employee)
        }
    );


    return await response.json();
}





export async function updateEmployee(id, employee)
{
    const response = await fetch(
        `${API_URL}/${id}`,
        {
            method: "PUT",

            headers:
            {
                "Content-Type": "application/json"
            },

            body: JSON.stringify(employee)
        }
    );


    return await response.json();
}