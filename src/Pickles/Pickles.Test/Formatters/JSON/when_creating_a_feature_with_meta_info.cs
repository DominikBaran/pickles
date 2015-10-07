﻿//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="when_creating_a_feature_with_meta_info.cs" company="PicklesDoc">
//  Copyright 2011 Jeffrey Cameron
//  Copyright 2012-present PicklesDoc team and community contributors
//
//
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using System.IO.Abstractions;
using NFluent;
using NUnit.Framework;
using PicklesDoc.Pickles.DirectoryCrawler;
using PicklesDoc.Pickles.DocumentationBuilders.JSON;
using PicklesDoc.Pickles.ObjectModel;

namespace PicklesDoc.Pickles.Test.Formatters.JSON
{
    public class when_creating_a_feature_with_meta_info : BaseFixture
    {
        private const string RELATIVE_PATH = @"AcceptanceTest";
        private const string ROOT_PATH = FileSystemPrefix + @"AcceptanceTest";
        private const string FEATURE_PATH = @"AdvancedFeature.feature";

        private FeatureNode _featureDirectoryNode;
        private FileInfoBase _featureFileInfo;
        private JsonFeatureWithMetaInfo _featureWithMeta;
        private Feature _testFeature;

        public void Setup()
        {
            this._testFeature = new Feature { Name = "Test" };
            this._featureFileInfo = this.FileSystem.FileInfo.FromFileName(FileSystem.Path.Combine(ROOT_PATH, FEATURE_PATH));
            this._featureDirectoryNode = new FeatureNode(this._featureFileInfo, RELATIVE_PATH, this._testFeature);

            this._featureWithMeta = new JsonFeatureWithMetaInfo(this._featureDirectoryNode);
        }

        [Test]
        public void it_should_contain_the_feature()
        {
            this.Setup();

            Check.That(this._featureWithMeta.Feature).IsNotNull();
            Check.That(this._featureWithMeta.Feature.Name).IsEqualTo("Test");
        }

        [Test]
        public void it_should_contain_the_relative_path()
        {
            this.Setup();

            Check.That(this._featureWithMeta.RelativeFolder).IsEqualTo(RELATIVE_PATH);
        }
    }
}