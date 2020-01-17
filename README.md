# Practice
Here I will place some projects that contain some of my practices, I like to practice my skills by doing things. 

## Practice LINQ
To practice some LINQ queries I've created a project with JSON data. In the Practice test project you're able to write some queries yourself. I'll add some test methods which will fail, but if you write the right query they will pass. Good luck! 

### Change mock data
To change the mock data with more records, you can change the mock file. I included a bigger file with 1000 mechanics, which is in the FileStorage assembly. 

**WARNING the recent tests won't pass with this mock size, you have to change the assertions yourself still** 
To use this mock: 
1. Go to the test file 
2. Change the `MechanicService` parameter in the constructor to: `MechanicResource.MECHANICS`

Old constructor:
```
        public ComprehensiveQueries(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _service = new MechanicService(MechanicTestResource.TESTMECHANICS);
        }
```

New constructor: 
```
        public ComprehensiveQueries(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _service = new MechanicService(MechanicResource.MECHANICS);
        }
```
*This is still really small, maybe I'll create an app for such things later.*
