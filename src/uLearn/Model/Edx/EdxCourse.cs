﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using uLearn.Model.Edx.EdxComponents;

namespace uLearn.Model.Edx
{
	[XmlRoot("course")]
	public class EdxCourse
	{
		[XmlAttribute("url_name")]
		public string UrlName { get; set; }

		[XmlAttribute("org")]
		public string Organization;

		[XmlAttribute("course")]
		public string CourseName;

		[XmlIgnore]
		public string[] StaticFiles;

		[XmlIgnore]
		public CourseWithChapters CourseWithChapters;

		public EdxCourse()
		{
		}

		public EdxCourse(string courseId, string organization, string courseTitle, string[] advancedModules, string[] ltiPassports, Chapter[] chapters)
		{
			CourseName = courseId;
			UrlName = courseId;
			Organization = organization;
			CourseWithChapters = new CourseWithChapters(courseId, courseTitle, advancedModules, ltiPassports, true, chapters);
			StaticFiles = Directory.GetFiles(string.Format("{0}/static", Utils.GetRootDirectory()));
		}

		private void CreateDirectories(string rootDir, params string[] subDirs)
		{
			if (!Directory.Exists(rootDir))
				Directory.CreateDirectory(rootDir);
			foreach (var subdir in subDirs.Select(subDir => string.Format("{0}/{1}", rootDir, subDir)).Where(subdir => !Directory.Exists(subdir)))
				Directory.CreateDirectory(subdir);
		}

		public void Save(string folderName)
		{
			CreateDirectories(folderName, "course", "chapter", "sequential", "vertical", "video", "html", "lti", "static", "problem");
			foreach (var file in StaticFiles)
				File.Copy(file, string.Format("{0}/static/{1}", folderName, Path.GetFileName(file)), true);
			
			var courseFile = string.Format("{0}/course.xml", folderName);
			if (File.Exists(courseFile))
				CourseWithChapters.UrlName = new FileInfo(courseFile).DeserializeXml<EdxCourse>().UrlName;
			else 
				File.WriteAllText(courseFile, this.XmlSerialize());

			CourseWithChapters.Save(folderName);
		}

		public static EdxCourse Load(string folderName)
		{
			var course = new FileInfo(string.Format("{0}/course.xml", folderName)).DeserializeXml<EdxCourse>();
			course.StaticFiles = Directory.GetFiles(string.Format("{0}/static", folderName));
			course.CourseWithChapters = CourseWithChapters.Load(folderName, course.UrlName);
			return course;
		}

		public void CreateUnsortedChapter(string folderName, Vertical[] verticals)
		{
			if (CourseWithChapters.Chapters.All(x => x.UrlName != "Unsorted"))
			{
				var chapters = new List<Chapter>(CourseWithChapters.Chapters);
				var newChapter = new Chapter("Unsorted", "Unsorted", new[] { new Sequential(Utils.NewNormalizedGuid(), "Unsorted " + DateTime.Now, verticals) });
				chapters.Add(newChapter);
				CourseWithChapters.Chapters = chapters.ToArray();
				CourseWithChapters.ChapterReferences = CourseWithChapters.Chapters.Select(x => new ChapterReference { UrlName = x.UrlName }).ToArray();

				File.WriteAllText(string.Format("{0}/course/{1}.xml", folderName, CourseWithChapters.UrlName), CourseWithChapters.XmlSerialize());
				newChapter.Save(folderName);
			}
			else
			{
				var testChapter = CourseWithChapters.Chapters.Single(x => x.UrlName == "Unsorted");
				var sequentials = new List<Sequential>(testChapter.Sequentials);
				var newSequential = new Sequential(Utils.NewNormalizedGuid(), "Unsorted " + DateTime.Now, verticals);
				sequentials.Add(newSequential);
				testChapter.Sequentials = sequentials.ToArray();
				testChapter.SequentialReferences = testChapter.Sequentials.Select(x => new SequentialReference { UrlName = x.UrlName }).ToArray();

				File.WriteAllText(string.Format("{0}/chapter/{1}.xml", folderName, testChapter.UrlName), testChapter.XmlSerialize());
				newSequential.Save(folderName);
			}
		}

		public Sequential GetSequentialContainingVertical(string verticalId)
		{
			var sequentials = CourseWithChapters.Chapters.SelectMany(
				x => x.Sequentials.Where(y => y.Verticals.Any(z => z.UrlName == verticalId))).ToList();
			if (sequentials.Count > 1)
				throw new Exception(
					string.Format("Vertical {0} are in several sequentials {1}", 
					verticalId, 
					string.Join(", ", sequentials.Select(s => s.UrlName))));
			return sequentials.Single();
		}

		public Vertical GetVerticalById(string id)
		{
			return CourseWithChapters
				.Chapters
				.SelectMany(x => x.Sequentials.SelectMany(y => y.Verticals))
				.FirstOrDefault(x => x.UrlName == id);
		}

		public VideoComponent GetVideoById(string id)
		{
			return CourseWithChapters
				.Chapters
				.SelectMany(x => x.Sequentials.SelectMany(y => y.Verticals.SelectMany(z => z.Components)))
				.OfType<VideoComponent>()
				.FirstOrDefault(x => x.UrlName == id);
		}
	}
}
