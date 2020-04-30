#region License
/*
VoikkoSharp

A wrapper library for the Voikko (Free linguistic software and data for Finnish).
Copyright © 2020 VPKSoft, Petteri Kautonen

Contact: vpksoft@vpksoft.net

This file is part of VoikkoSharp.

VoikkoSharp is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

VoikkoSharp is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with VoikkoSharp.  If not, see <http://www.gnu.org/licenses/>.
*/
#endregion

using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using libvoikko;
using VoikkoSharp;
using VPKSoft.SpellCheckUtility;
using VPKSoft.SpellCheckUtility.WinForms;

namespace VoikkoSharpTestApp
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            // load the DLL suitable for the architecture..
            //PrepareVoikko.Prepare();

            var voikko = new VoikkoExternalSpellCheck();
            voikko.Initialize();

            
            SpellChecker.ExternalDictionary = voikko;

            // subscribe to the event which is called by the SpellChecker class on progressing with the spell checking;
            // there is no reason to subscribe this event if the checking isn't visualized or done in real-time..
            SpellChecker.SpellCheckLocationChanged += SpellChecker_SpellCheckLocationChanged;
        }

        private Voikko Voikko { get; }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Voikko?.Dispose();
            SpellChecker.SpellCheckLocationChanged -= SpellChecker_SpellCheckLocationChanged;
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            if (odTextFile.ShowDialog() == DialogResult.OK)
            {
                tbSpellCheck.Text = File.ReadAllText(odTextFile.FileName);
            }
        }

        /// <summary>
        /// Gets or sets the text offset correction. This is used in the real time spell checking..
        /// </summary>
        /// <value>The text offset correction.</value>
        private int TextOffsetCorrection { get; set; }

        // the real-time spell checking event..
        private void SpellChecker_SpellCheckLocationChanged(object sender, VPKSoft.SpellCheckUtility.UtilityClasses.SpellCheckLocationChangeEventArgs e)
        {
            // set the selection for the misspelled word..
            tbSpellCheck.SelectionStart = e.SpellingError.StartLocation + TextOffsetCorrection;
            tbSpellCheck.SelectionLength = e.SpellingError.Length;

            // if a correction for the spelling error was made..
            if (e.AfterSpellCheck) 
            {
                // ..fix the error in real time..
                tbSpellCheck.SelectedText = e.SpellingError.CorrectedWord;

                // ..set the offset, so this doesn't get messy..
                TextOffsetCorrection += e.SpellingError.CorrectedWord.Length - e.SpellingError.Length;
            }

            // scroll the "view" into visibility..
            tbSpellCheck.ScrollToCaret();
        }

        // start a real-time spell checking for the text..
        private void mnuSpellCheck_Click(object sender, EventArgs e)
        {
            TextOffsetCorrection = 0; // re-set the offset..
            // create a new instance of the spell checker class..
            var spellChecker = new SpellChecker();

            // create a new spell checking dialog (implementing the ISpellCheck) interface..
            FormDialogSpellCheck.OwnerWindow = this;

            // set the locale to Finnish as some one might understand whats going on with the dialog,
            // if a more common locale would be used;
            FormDialogSpellCheck.Locale = "fi-FI"; 
            var spellingDialog = new FormDialogSpellCheck();

            // run the spell check..
            spellChecker.RunSpellCheckInterface(spellingDialog, tbSpellCheck.Text, false);
        }
    }
}
