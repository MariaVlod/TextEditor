﻿using System.Diagnostics;
using System.Windows.Controls;
using TextEditor.Models;

namespace TextEditor.UserControls
{
    public interface IUserControlFactory
    {
        UserControl CreateUserControl(UserControlTypes userControl, Document? document, Action<UserControlTypes, Document> userControlHandler);
    }

    public class UserControlFactory : IUserControlFactory
    {
        public UserControl CreateUserControl(UserControlTypes userControl, Document? document, Action<UserControlTypes, Document> userControlHandler)
        {
            switch (userControl)
            {
                case UserControlTypes.Edit:
                    var editUserControl = new EditUserControl(document);
                    editUserControl.UserControlSwitched += userControlHandler;
                    return editUserControl;

                case UserControlTypes.Preview:
                    var previewUserControl = new PreviewUserControl(document);
                    previewUserControl.UserControlSwitched += userControlHandler;
                    return previewUserControl;

                default:
                    throw new ArgumentException("Invalid user control type");
            }
        }
    }
}
