//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Procure Development">
//     Copyright (c) Procure Development. All rights reserved.
// </copyright>
// <author>Victor Procure</author>
//-----------------------------------------------------------------------
namespace FillDownGridViewTest
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Main program class
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FillDownGridViewTest());
        }
    }
}