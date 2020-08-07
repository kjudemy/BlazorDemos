using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// Additional Namespace
using Microsoft.AspNetCore.Components;

namespace BlazorTimes.Client.Pages.Binding
{
    public partial class BindingClass
    {
        public string Message { get; set; } = "We have already seen expressions!";
        public bool HideOne { get; set; } = false;
        public bool HideTwo { get; set; } = false;
        public void UseHideTwo() => HideTwo = !HideTwo;

        public string EntryOne { get; set; }
        public string EntryTwo { get; set; }
        public string EntryThree { get; set; }
        public string EntryFour { get; set; }
        public string EntryFive { get; set; }
        public string EntrySix { get; set; }
        public void SetValueFour(ChangeEventArgs e)
        {
            EntryFour = (string)e.Value;
        }
        public void SetValueSix(ChangeEventArgs e)
        {
            EntrySix = (string)e.Value;
        }
    }
}
