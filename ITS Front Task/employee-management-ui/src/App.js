import './App.css';
import EmployeeList from './EmployeeList';
import EmployeeForm from './EmployeeForm';
import { useEffect, useState } from "react";
import { getEmployees } from "./api";

function App() {
  const [employees, setEmployees] = useState([]);

  const [selectedEmployee, setSelectedEmployee] = useState(null);
  useEffect(() => {

    const fetchEmployees = async () => {

      const data = await getEmployees();

      setEmployees(data);

    };


    fetchEmployees();

  }, []);
  return (
    <div className="app-container mt-5">


      <h1  className="text-center mb-4">
        Employee Management System
      </h1>

  <EmployeeForm 
    setEmployees={setEmployees}
    selectedEmployee={selectedEmployee}
    setSelectedEmployee={setSelectedEmployee}
/>

  <hr />

    

     <EmployeeList 
    employees={employees}
    setEmployees={setEmployees}
    setSelectedEmployee={setSelectedEmployee}
/>

    </div>
  );
}

export default App;
