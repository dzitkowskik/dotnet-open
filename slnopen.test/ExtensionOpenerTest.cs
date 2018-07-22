namespace Slnopen.Test
{
    using System;
    using System.Collections.Generic;
    using System.IO.Abstractions.TestingHelpers;
    using FluentAssertions;
    using Xunit;

    public class ExtensionOpenerTest
    {
        [Fact]
        public void Ctor_WithNullValues_ShouldThrow()
        {
            // Act
            Action action = () => new ExtensionOpener(null, null);

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Open_WithoutSelectedFile_ShouldOpenAllSlnFilesInCurrentDirectory()
        {
            // Arrange
            var(uut, programRunner, fileSystem) = this.PrepareUseCaseWithTwoFilesInCurrentDirectory();

            // Act
            uut.Open(new Options() { Extension = "sln" });

            // Assert
            programRunner.OpenedFiles.Should().BeEquivalentTo(fileSystem.AllFiles);
        }

        [Fact]
        public void Open_SelectedFile_ShouldOpenOnlySelectedFile()
        {
            // Arrange
            var selectedFile = @"second.sln";
            var(uut, programRunner, fileSystem) = this.PrepareUseCaseWithTwoFilesInCurrentDirectory();

            // Act
            uut.Open(new Options() { SelectedFile = selectedFile });

            // Assert
            programRunner.OpenedFiles.Should().HaveCount(1);
            programRunner.OpenedFiles.Should().Contain(t => t.EndsWith(selectedFile));
        }

        [Fact]
        public void Edit_WithoutSelectedFile_ShouldEditAllSlnFilesInCurrentDirectory()
        {
            // Arrange
            var(uut, programRunner, fileSystem) = this.PrepareUseCaseWithTwoFilesInCurrentDirectory();

            // Act
            uut.Open(new Options() { Extension = "sln", EditMode = true });

            // Assert
            programRunner.EditedFiles.Should().BeEquivalentTo(fileSystem.AllFiles);
        }

        [Fact]
        public void Edit_SelectedFile_ShouldEditOnlySelectedFile()
        {
            // Arrange
            var selectedFile = @"second.sln";
            var(uut, programRunner, fileSystem) = this.PrepareUseCaseWithTwoFilesInCurrentDirectory();

            // Act
            uut.Open(new Options() { EditMode = true, SelectedFile = selectedFile });

            // Assert
            programRunner.EditedFiles.Should().HaveCount(1);
            programRunner.EditedFiles.Should().Contain(t => t.Contains(selectedFile));
        }

        private(ExtensionOpener, MockProgramRunner, MockFileSystem) PrepareUseCaseWithTwoFilesInCurrentDirectory()
        {
            var fileSystem = new MockFileSystem(new Dictionary<string, MockFileData>
            {
                { @"first.sln", new MockFileData("TEST") },
                { @"second.sln", new MockFileData("TEST") }
            });

            var programRunner = new MockProgramRunner();

            var uut = new ExtensionOpener(programRunner, fileSystem);

            return (uut, programRunner, fileSystem);
        }
    }
}
