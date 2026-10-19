using System;
[Serializable]
public class Employee
{
    public string name;
    public string lastEntranceInEngineRoom;
    public string lastExitFromEngineRoom;
    public int employeeId;
    public bool hasEngineRoomClearance;
}
[Serializable]
public class EmployeeData
{
    public Employee[] employees;
}
