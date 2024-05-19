Here are the steps to clone a GitHub repository, pull the code, restore NuGet packages, build, and run the API:

 Prerequisites:
- Ensure that you have Git installed on your machine. You can download it from [here](https://git-scm.com/).
- Ensure that you have .NET Core SDK installed on your machine. You can download it from [here](https://dotnet.microsoft.com/download/dotnet-core).
- Ensure that you have an IDE like Visual Studio or Visual Studio Code installed on your machine.

 Steps:

1. Clone the GitHub Repository:
   - Open a terminal or command prompt.
   - Navigate to the directory where you want to clone the repository.
   - Use the `git clone` command followed by the repository URL. For example:
     
     git clone https://github.com/yourusername/your-repository.git
     
   - Replace `https://github.com/yourusername/your-repository.git` with the actual URL of your GitHub repository.

2. Navigate to the Cloned Repository:
   - Change the directory to the cloned repository:
     
     cd your-repository
     
   - Replace `your-repository` with the name of your cloned repository.

3. Pull the Latest Code:
   - Ensure that you have the latest code from the repository by pulling it:
     
     git pull
     

4. Restore NuGet Packages:
   - Open the solution file (`.sln`) in Visual Studio or navigate to the project directory in your terminal.
   - If using Visual Studio:
     - Right-click on the solution in the Solution Explorer and select `Restore NuGet Packages`.
   - If using the terminal:
     - Run the following command to restore NuGet packages:
       
       dotnet restore
       

5. Build the Solution:
   - If using Visual Studio:
     - Press `Ctrl+Shift+B` to build the solution, or right-click on the solution in Solution Explorer and select `Build Solution`.
   - If using the terminal:
     - Run the following command to build the solution:
       
       dotnet build
       

6. Run the API:
   - If using Visual Studio:
     - Press `F5` to run the project, or click on the `Run` button.
   - If using the terminal:
     - Navigate to the project directory (where the `.csproj` file is located) and run the following command:
       
       dotnet run
       

 
# Currency Converter API

This repository contains the Currency Converter API built with ASP.NET Core.

 Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download/dotnet-core)
- [Git](https://git-scm.com/)
- An IDE such as Visual Studio or Visual Studio Code

 Getting Started

 Cloning the Repository


git clone https://github.com/yourusername/your-repository.git
cd your-repository


Pulling the Latest Code

git pull

Restoring NuGet Packages

dotnet restore

Building the Solution

dotnet build

Running the API

dotnet run


 Running with Visual Studio

1. Open the solution file (`.sln`) in Visual Studio.
2. Right-click on the solution and select `Restore NuGet Packages`.
3. Build the solution by pressing `Ctrl+Shift+B`.
4. Run the project by pressing `F5`.

 Running with Visual Studio Code

1. Open the project in Visual Studio Code:
  
   code .
   
2. Restore NuGet packages:
   
   dotnet restore
   
3. Build the project:
   
   dotnet build
   
4. Run the project:
   
   dotnet run
   
