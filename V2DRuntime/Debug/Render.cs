/*
* Box2D.XNA port of Box2D:
* Copyright (c) 2009 Brandon Furtwangler, Nathan Furtwangler
*
* Original source Box2D:
* Copyright (c) 2006-2009 Erin Catto http://www.gphysics.com 
* 
* This software is provided 'as-is', without any express or implied 
* warranty.  In no event will the authors be held liable for any damages 
* arising from the use of this software. 
* Permission is granted to anyone to use this software for any purpose, 
* including commercial applications, and to alter it and redistribute it 
* freely, subject to the following restrictions: 
* 1. The origin of this software must not be misrepresented; you must not 
* claim that you wrote the original software. If you use this software 
* in a product, an acknowledgment in the product documentation would be 
* appreciated but is not required. 
* 2. Altered source versions must be plainly marked as such, and must not be 
* misrepresented as being the original software. 
* 3. This notice may not be removed or altered from any source distribution. 
*/

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace V2DRuntime.Debug
{
    public class DebugDraw
    {

        public DebugDraw()
        {
            _stringData = new List<StringData>();
        }

        public void DrawString(int x, int y, string s)
        {
            _stringData.Add(new StringData(x, y, s, null));
        }

        public void DrawString(int x, int y, string s, params object[] args)
        {
            _stringData.Add(new StringData(x, y, s, args));
        }

        public void FinishDrawShapes()
        {
            _device.BlendState = BlendState.AlphaBlend;

            //_device.RenderState.CullMode = CullMode.None;
            //_device.RenderState.AlphaBlendEnable = true;

            if (_fillCount > 0)
                _device.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, _vertsFill, 0, _fillCount);

            if (_lineCount > 0)
                _device.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.LineList, _vertsLines, 0, _lineCount);

            _lineCount = _fillCount = 0;
        }

        public void FinishDrawString()
        {
            for (int i = 0; i < _stringData.Count; i++)
            {
                var text = _stringData[i].args == null ? _stringData[i].s : string.Format(_stringData[i].s, _stringData[i].args);
                _batch.DrawString(_font, text, new Vector2(_stringData[i].x, _stringData[i].y), new Color(0.9f, 0.6f, 0.6f));
            }

            _stringData.Clear();
        }

        public static VertexPositionColor[] _vertsLines = new VertexPositionColor[100000];
        public static VertexPositionColor[] _vertsFill = new VertexPositionColor[100000];
        public static int _lineCount;
        public static int _fillCount;
        public static SpriteBatch _batch;
        public static SpriteFont _font;
        public static GraphicsDevice _device;

        private List<StringData> _stringData;
        struct StringData
        {
            public StringData(int x, int y, string s, object[] args)
            {
                this.x = x;
                this.y = y;
                this.s = s;
                this.args = args;
            }

            public int x, y;
            public string s;
            public object[] args;
        }
    }
}
