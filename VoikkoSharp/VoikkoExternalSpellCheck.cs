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
using System.Collections.Generic;
using System.Runtime.InteropServices;
using libvoikko;
using VPKSoft.SpellCheck.ExternalDictionarySource;

namespace VoikkoSharp
{
    /// <summary>
    /// An interface to be used with the Voikko and any spell checking library which supports IExternalDictionarySource interface.
    /// Currently VPKSoft.SpellCheckUtility and VPKSoft.ScintillaSpellCheck supports the interface.
    /// Implements the <see cref="VPKSoft.SpellCheck.ExternalDictionarySource.IExternalDictionarySource" />
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="VPKSoft.SpellCheck.ExternalDictionarySource.IExternalDictionarySource" />
    /// <seealso cref="System.IDisposable" />
    public class VoikkoExternalSpellCheck : IExternalDictionarySource, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VoikkoExternalSpellCheck"/> class.
        /// </summary>
        /// <param name="voikko">The <see cref="Voikko"/> instance to use with the spell checking.</param>
        public VoikkoExternalSpellCheck(Voikko voikko)
        {
            Voikko = voikko;
        }

        /// <summary>
        /// Gets or sets the <see cref="Voikko"/> class instance.
        /// </summary>
        private Voikko Voikko { get; set; }

        /// <summary>
        /// Gets spelling correction suggestions for a specified miss-spelled word.
        /// </summary>
        /// <param name="word">The miss-spelled word to get correction suggestions for.</param>
        /// <returns>A IEnumerable&lt;System.String&gt; of correction suggestions for the word.</returns>
        public IEnumerable<string> Suggest(string word)
        {
            return Voikko.Suggest(word);
        }

        /// <summary>
        /// Checks whether the specified word is spelled correctly.
        /// </summary>
        /// <param name="word">The word to check.</param>
        /// <returns><c>true</c> if the word is spelled correctly, <c>false</c> otherwise.</returns>
        public bool Check(string word)
        {
            return Voikko.Spell(word);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources..
                Voikko?.Dispose();
            }
        
            // free native resources if there are any..
            // NONE (That I know of)..
        }
    }
}
