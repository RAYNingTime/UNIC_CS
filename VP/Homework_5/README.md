# Homework 5
## COMP-213 Visual Programming

0. Write an application with more practical fields and layout for managing list of students.
Your application will consist of two parts:

- Adding student that will ask user for students’ details as well as their address. A
  diverse range of fields are requested, so you should use the appropriate controls
  to prompt user for their input. (See the screenshot below for reference.
- Allow user to export existing students that are selected. If the user wishes to
import student, you prompt them to select the file with the students and the
application will add them to the list on the right side.

As for the design, aim to make it similar like this (hint: use Border and then the intended
control inside)

![image](https://user-images.githubusercontent.com/92152254/215044037-9e7e1e73-16fd-4ec5-81ce-639b6e40c881.png)

___

1. Make a small bulletin board application. The user can enter a title and a description and
then press Add to add an entry to the list below. Each entry is a expander with header
set to the title and the body being a stackpanel of a label with the description and a
remove button. If user clicks remove, the entry should then be removed from the list.
(this might be a bit challenging but go for it and see how it goes!)

[**TRY**] adding the 2nd panel as a child of a ScrollViewer control and see what happens!
```
<ScrollViewer>
  <StackPanel>
  ...
  </StackPanel>
</ScrollViewer>
```

![image](https://user-images.githubusercontent.com/92152254/215044255-7f1c602d-a243-4764-acb1-d9b6ff207f3b.png)

___

2. You are requested to create the UI for digitization of student service request of our
university. Try to re-create the following form with XAML (no functionality! + you can
skip the logo) and make improvements were possible (e.g. using ComboBox instead of TextBox)

![image](https://user-images.githubusercontent.com/92152254/215044400-90477430-d734-4014-b6dd-4346cf95533c.png)

