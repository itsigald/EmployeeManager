# Project Requirements:
Create a web application that represents organization structure.

## Specifications:
- The organization structure consists of two types of persons:
  - Employee
  - Manager
- Employee has the following attributes: First Name, Last Name, Position
- Manager may have number of Employees and managers reporting to him
- Employee can report to its direct manager
  - Report has two attributes: report text and report date
- Manager can assign tasks to its direct subordinates.
  - Task has three attributes: tasks text, assign date and due date
- Employee can see a list of tasks assigned to him
- Manager can see a list of reports from its subordinates

## UI specification:
#### Employee list window:
![image](https://user-images.githubusercontent.com/426076/220254438-a2e662e3-cafd-4ec0-93cd-ba351eb54b08.png)

When clicking on View button in employee list the Employee Details view should be presented:

#### Employee Details Window:
![image](https://user-images.githubusercontent.com/426076/220254520-0bf410af-717f-4448-b513-17680d2fc140.png)

When clicking on “Report” button a popup should be presented. The popup should contain text field for report text and “Save”/:Cancel” buttons. If “Save” is clicked the report text with current date should be added to report log of direct manager. <br /><br />
When clicking on “Assign Task” button a popup should be presented. This popup should have task text and due date fields and Save/Cancel buttons. When Save button is pressed the task with current data as creation date should be added to corresponded Employee task log.
