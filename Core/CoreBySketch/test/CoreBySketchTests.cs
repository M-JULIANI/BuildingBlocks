﻿using Xunit;
using System.Linq;
using Newtonsoft.Json;
using Elements;
using Elements.Geometry;
using Hypar.Functions.Execution.Local;
using Elements.Serialization.glTF;
using Elements.Serialization.JSON;
using System.Collections.Generic;


namespace CoreBySketch.tests
{
    public class CoreBySketchTests
    {
        [Fact]
        public void CoreBySketchTest()
        {
            var polygon =
                new Polygon
                (
                    new[]
                    {
                        new Vector3(30.0, 30.0),
                        new Vector3(60.0, 30.0),
                        new Vector3(60.0, 60.0),
                        new Vector3(30.0, 60.0)
                    }
                );
            var model = Model.FromJson(System.IO.File.ReadAllText("../../../../../../TestOutput/LevelsByEnvelope.json"));
            var inputs = new CoreBySketchInputs(polygon, 3.0, "", "", new Dictionary<string, string>(), "", "", "");
            var outputs = CoreBySketch.Execute(new Dictionary<string, Model>{{"Levels", model}}, inputs);
            System.IO.File.WriteAllText("../../../../../../TestOutput/CoreBySketch.json", outputs.Model.ToJson());
            outputs.Model.ToGlTF("../../../../../../TestOutput/CoreBySketch.glb");
        }
    }
}
