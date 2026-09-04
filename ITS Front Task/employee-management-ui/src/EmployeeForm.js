import { useState, useEffect } from "react";
import {
    addEmployee,
    updateEmployee,
    getEmployees
} from "./api";


function EmployeeForm({ setEmployees, selectedEmployee  , setSelectedEmployee }) {


    const [employee, setEmployee] = useState({
        fullName: "",
        email: "",
        department: "",
        jobTitle: "",
        hireDate: ""
    });

    useEffect(() => {

        if (selectedEmployee) {
            setEmployee(selectedEmployee);
        }

    }, [selectedEmployee]); //every time selectedEmployee changes this useEffect will run 

    const handleChange = (e) => {

        setEmployee({
            ...employee,
            [e.target.name]: e.target.value // computed property name يعني اسم الخاصية يتحدد حسب القيمة.
        });

    };


    const handleSubmit = async (e) => {

        e.preventDefault(); //عشان نبلوك الريفريش او الريندر

        if (selectedEmployee) {
            await updateEmployee(
                selectedEmployee.employeeId,
                employee
            );
        }
        else {
            await addEmployee(employee);
        }
        const data = await getEmployees();

        setEmployees(data);

setSelectedEmployee(null); /// كانت ملغبطانى


        setEmployee({
            fullName: "",
            email: "",
            department: "",
            jobTitle: "",
            hireDate: ""
        });


    };

    return (
        <div className="card p-4 shadow mb-4">

           <h2 className="mb-3">
{
    selectedEmployee
    ? "Update Employee"
    : "Add Employee"
}
</h2>

            <input
            className="form-control mb-3"
                type="text"
                placeholder="Full Name"
                value={employee.fullName}
                // onChange={(e) =>    //اسمه Controlled Component يعني كل ما اكتب في ال input يتغير ال state و كل ما يتغير ال state يتغير ال input 
                //     setEmployee({
                //         ...employee,
                //         fullName: e.target.value
                //     })
                // }
                onChange={handleChange}
                name="fullName"
            />


            <input
            className="form-control mb-3"
                type="email"
                placeholder="Email"
                value={employee.email}
                onChange={handleChange}
                name="email"
            />


            <input
            className="form-control mb-3"
                type="text"
                placeholder="Department"
                value={employee.department}
                onChange={handleChange}
                name="department"
            />


            <input
            className="form-control mb-3"
                type="text"
                placeholder="Job Title"
                value={employee.jobTitle}
                onChange={handleChange}
                name="jobTitle"
            />


            <input
            className="form-control mb-3"
                type="date"
                value={employee.hireDate}
                onChange={handleChange}
                name="hireDate"
            />


            <button className="btn btn-primary w-100" onClick={handleSubmit}>
                {
                selectedEmployee
                ? "Update Employee"
                : "Add Employee"
}
            </button>

        </div>
    );

}


export default EmployeeForm;