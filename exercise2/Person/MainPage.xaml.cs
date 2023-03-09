using Person.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Person
{
public partial class MainPage : ContentPage
{
public MainPage()
{
InitializeComponent();
}
    private async void OnNewButtonClicked(object sender, EventArgs args)
    {
        statusMessage.Text = "";

        try
        {
            string newName = newPerson.Text.Trim();

            if (string.IsNullOrEmpty(newName))
                throw new ArgumentException("Valid name required", nameof(newName));

            await App.PersonRepo.AddNewPerson(newName);

            statusMessage.Text = App.PersonRepo.StatusMessage;
        }
        catch (Exception ex)
        {
            statusMessage.Text = $"Failed to add person. Error: {ex.Message}";
        }
    }

    private async void OnGetButtonClicked(object sender, EventArgs args)
    {
        statusMessage.Text = "";

        try
        {
            List<Person> person = await App.PersonRepo.GetAllPerson();
            personList.ItemsSource = person;
        }
        catch (Exception ex)
        {
            statusMessage.Text = $"Failed to retrieve person. Error: {ex.Message}";
        }
    }
}
}

