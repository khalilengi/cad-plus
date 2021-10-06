﻿//*********************************************************************
//CAD+ Toolset
//Copyright(C) 2021 Xarial Pty Limited
//Product URL: https://cadplus.xarial.com
//License: https://cadplus.xarial.com/license/
//*********************************************************************

using System;
using System.Windows;
using Xarial.CadPlus.Plus.Services;

namespace Xarial.CadPlus.Plus.Shared.Services
{
    public class GenericMessageService : IMessageService
    {
        public Type[] UserErrors { get; }

        public void ShowError(string error) => ShowMessage(error, MessageBoxImage.Error);
        public void ShowInformation(string msg) => ShowMessage(msg, MessageBoxImage.Information);
        public void ShowWarning(string warn) => ShowMessage(warn, MessageBoxImage.Warning);

        public bool? ShowQuestion(string question)
        {
            switch (ShowMessage(question, MessageBoxImage.Information, MessageBoxButton.YesNoCancel)) 
            {
                case MessageBoxResult.Yes:
                    return true;

                case MessageBoxResult.No:
                    return false;

                default:
                    return null;
            }
        }

        private readonly string m_Title;

        public GenericMessageService() : this("CAD+ Toolset")
        {
        }

        public GenericMessageService(string title) 
        {
            m_Title = title;
        }

        public GenericMessageService(string title, Type[] userErrors) : this(title)
        {
            UserErrors = userErrors;
        }

        public MessageBoxResult ShowMessage(string msg, MessageBoxImage img, MessageBoxButton btn = MessageBoxButton.OK)
            => MessageBox.Show(msg, m_Title, btn, img);
    }
}
