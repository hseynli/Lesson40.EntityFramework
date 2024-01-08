--1
CREATE PROCEDURE [dbo].[FindStudents]
    @SearchFor NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM Students WHERE [Name] LIKE '%' + @SearchFor + '%'
END

--2
CREATE PROCEDURE [dbo].[FindStudentsAlt]
    @SearchFor NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        StudentName = S.[Name],
        CourseTitle = C.Title
    FROM 
        Students S
    LEFT JOIN Courses C ON S.CourseId = C.Id 
    WHERE 
        S.[Name] LIKE '%' + @SearchFor + '%'
END

--3
CREATE PROCEDURE UpdateStudentMark
    @Id int,
    @Mark int
AS
BEGIN
    UPDATE 
        Students
    SET 
        Mark = @Mark
    WHERE 
        Id = @Id;
END


--4
CREATE PROCEDURE UpdateStudentMarkWithReturnValue
    @Id int,
    @Mark int,
    @AvgMark int OUTPUT
AS
BEGIN
    UPDATE 
        Students
    SET 
        Mark = @Mark
    WHERE 
        Id = @Id;
    SELECT @AvgMark = AVG(Mark) FROM Students
END