import { useState } from "react";

import { getEmployees, deleteEmployee } from "./api";

function EmployeeList({ employees, setEmployees, setSelectedEmployee }) {


    // const [employees, setEmployees] = useState([]);

    const [search, setSearch] = useState("");




    const handleDelete = async (id) => {

        const confirmDelete =
            window.confirm("Are you sure you want to delete this employee?");


        if (confirmDelete) {
            await deleteEmployee(id);

            const data = await getEmployees();

            setEmployees(data);
        }

    };


    const filteredEmployees = employees.filter(employee => {
        return (
            employee.fullName
                .toLowerCase()
                .includes(search.toLowerCase())
            ||
            employee.email
                .toLowerCase()
                .includes(search.toLowerCase())
        );
    });






    return (
        <div>

            <h2>
                Employees List
            </h2>

            <input
                className="form-control mb-3"
                type="text"
                placeholder="Search by name or email"
                value={search}
                onChange={(e) => setSearch(e.target.value)}
            />


            <p>
                Number of Employees: {employees.length}
            </p>

           <div className="table-responsive shadow">

<table className="table table-hover table-striped table-bordered mb-0">

                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Name</th>
                        <th>Email</th>
                        <th>Department</th>
                        <th>Job Title</th>
                        <th>Hire Date</th>
                    </tr>
                </thead>


                <tbody>

                    {
                        filteredEmployees.map(employee => (

                            <tr key={employee.employeeId}>

                                <td>{employee.employeeId}</td>

                                <td>{employee.fullName}</td>

                                <td>{employee.email}</td>

                                <td>{employee.department}</td>

                                <td>{employee.jobTitle}</td>

                                <td>{employee.hireDate}</td>


                                <td>

                                    <button
                                        className="btn btn-warning btn-sm me-2"
                                        onClick={() => setSelectedEmployee(employee)}
                                    >
                                        Edit
                                    </button>


                                    <button
                                        className="btn btn-danger btn-sm"
                                        onClick={() => handleDelete(employee.employeeId)}
                                    >
                                        Delete
                                    </button>

                                </td>



                            </tr>

                        ))
                    }

                </tbody>


            </table>

</div>
        </div>
    );

}


export default EmployeeList;