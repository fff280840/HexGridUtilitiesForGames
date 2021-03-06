﻿#region The MIT License - Copyright (C) 2012-2019 Pieter Geerkens
/////////////////////////////////////////////////////////////////////////////////////////
//                PG Software Solutions - Hex-Grid Utilities
/////////////////////////////////////////////////////////////////////////////////////////
// The MIT License:
// ----------------
// 
// Copyright (c) 2012-2019 Pieter Geerkens (email: pgeerkens@users.noreply.github.com)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this
// software and associated documentation files (the "Software"), to deal in the Software
// without restriction, including without limitation the rights to use, copy, modify, 
// merge, publish, distribute, sublicense, and/or sell copies of the Software, and to 
// permit persons to whom the Software is furnished to do so, subject to the following 
// conditions:
//     The above copyright notice and this permission notice shall be 
//     included in all copies or substantial portions of the Software.
// 
//     THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
//     EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
//     OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND 
//     NON-INFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT 
//     HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
//     WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING 
//     FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR 
//     OTHER DEALINGS IN THE SOFTWARE.
/////////////////////////////////////////////////////////////////////////////////////////
#endregion
using System;
using System.Drawing;

using PGNapoleonics.HexUtilities;
using PGNapoleonics.HexUtilities.Common;

namespace PGNapoleonics.HexgridPanel {
    public interface IMapDisplayPainter {
        /// <summary>Paint the base layer of the display, graphics that changes rarely between refreshes.</summary>
        /// <param name="graphics">The <see cref="Graphics"/> object for the canvas being painted.</param>
        /// <param name="showHexgrid">.</param>
        /// <remarks>For each visible hex: perform <c>paintAction</c> and then draw its hexgrid outline.</remarks>
        void PaintMap(Graphics graphics, bool showHexgrid);

        /// <summary>Paint the base layer of the display, graphics that changes rarely between refreshes.</summary>
        /// <param name="graphics">The <see cref="Graphics"/> object for the canvas being painted.</param>
        /// <param name="hexText">.</param>
        /// <remarks>For each visible hex: perform <c>paintAction</c> and then draw its hexgrid outline.</remarks>
        void PaintLabels(Graphics graphics, Func<HexCoords,string> hexText);

        /// <summary>Paints all the hexes in <paramref name="clipHexes"/> by executing <paramref name="paintAction"/>
        /// for each hex on <paramref name="graphics"/>.</summary>
        /// <param name="graphics">The <see cref="Graphics"/> object for the canvas being painted.</param>
        /// <param name="paintAction">The paint action to be performed for each hex as a <see cref="Action{HexCoords}"/>.</param>
        void PaintForEachHex(Graphics graphics, Action<HexCoords> paintAction);

        /// <summary>Paint the top layer of the display, graphics that changes frequently between refreshes.</summary>
        /// <param name="graphics">The <see cref="Graphics"/> object for the canvas being painted.</param>
        void PaintHighlight(Graphics graphics);

        /// <summary>.</summary>
        /// <param name="graphics">The <see cref="Graphics"/> object for the canvas being painted.</param>
        /// <param name="isNotShaded">The <see cref="IShadingMask"/> object for the canvas being painted.</param>
        void PaintShading(Graphics graphics, IShadingMask isNotShaded);

        /// <summary>.</summary>
        /// <typeparam name="THex"></typeparam>
        /// <param name="graphics">The <see cref="Graphics"/> object for the canvas being painted.</param>
        void PaintUnits(Graphics graphics);
    }
}
