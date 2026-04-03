# Copy entire solution
COPY . .
RUN dotnet restore MyDotNetApp.sln
RUN dotnet publish -c Release -o /app/publish

# Or for single project
COPY . .
RUN dotnet restore MyDotNetApp/MyDotNetApp.csproj
