namespace :example do

desc 'run a monitor example'
task :monitor do
  Dir.chdir('Examples/Monitor') do
    system "dotnet run"
  end
end

end


namespace :test do

  desc 'run the unit test'
  task :unit do
    system "dotnet test IRBoardLibTest/IRBoardLibTest.csproj"
  end
  
  end
  