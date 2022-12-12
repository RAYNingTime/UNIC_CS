# COMP-213 Visual Programming
## Final Practices

So, here’s the plan:
  - Let’s make a bunch of applications to make sure we’re ready for the farewell party!

_Global Note: you should use WPF for these exercises and use appropriate controls (e.g. grid,
checkbox, radio button, label, etc.) to display the UI._

**Exercise 0: Main Menu**

This will be a simple window with 3 buttons that will show the next 3 exercises. Make sure that
when each button is clicked, this window is hidden and only the selected exercise’s window is
shown. Once that exercise’s window is closed, main window should be shown again.

![image](https://user-images.githubusercontent.com/92152254/207039825-cb5b55d3-20a3-4246-b0d1-0ffec598edee.png)

___

**Exercise 1: Shopping List**

This exercise intends to help user keep track of their shopping items and remove the ones they want
easily. Every time user clicks on Add button, you should make sure a name and a quantity (valid
number) is provided, otherwise display an appropriate error. If the item’s name and quantity is valid,
you should add a checkbox with the name and quantity in **{quantity}x {name}** format. Finally, when
user clicks on Remove Selected Items, every checkbox that is checked must be removed from the
list. (you should NOT ask them if they want to remove, just remove them.)

![image](https://user-images.githubusercontent.com/92152254/207039980-cafcc8df-8d45-4099-a50b-deeb1b7039e3.png)

___

**Exercise 2: Tax Calculator**

You are asked to make a tax calculator application. For this exercise, the user enters their salary,
whether the amount is monthly/annual salary, as well as indication of user receiving 13th month
salary. In order to calculate the tax, you should first calculate the annual (if monthly is given) as well
as monthly (if annual is given).

- First calculate the gross annual salary (number of months x monthly salary).
- Then calculate the social insurance (which is 4.56 % of the gross salary).
- Then calculate the tax based on (gross – social insurance)
- - If this value is greater than 25000, the amount after 25000 receives a 10 % tax
- - Otherwise, there is no tax
- - (For this exercise the tax tiers are simplified)
- Net is the gross salary excluding the tax and social insurance amount

Every time user changes the amount, monthly/annual, or the 13th month indicator, values must be
updated (if the salary is invalid, you should display an appropriate error)

_Note 1: Number of months is 12 unless 13th monthly salary is selected._

_Note 2: Make sure your application outputs the following values shown below._

![image](https://user-images.githubusercontent.com/92152254/207040281-315db515-ba25-41ce-b88f-7f0c1fcef1a6.png)

___

**Exercise 3: House Customizer**

You are asked to make a part of an application that allows user to submit a request for their house.
There are series of choices on the screen that the user can select. Once they have selected the
submit button, you should display a message reflecting every choice they made (including their
choices in the final message) and ask them to confirm their request. Only IF they select Yes, you
should then display a thank you message. (you use appropriate code so your application will look like
the following.

![image](https://user-images.githubusercontent.com/92152254/207040353-5e533065-144c-44a2-b606-719b007fa1a5.png)
