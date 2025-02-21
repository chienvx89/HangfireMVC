# Project Title

Mô tả cách đưa hangfire vào một project aspnetCore (đang sử dụng net core 9.0)

## Table of Contents

- [Project Title](#project-title)
  - [Table of Contents](#table-of-contents)
  - [Installation](#installation)
  - [Usage](#usage)
  - [Contributing](#contributing)
  - [License](#license)

## Installation

Tham khảo link : https://code-maze.com/hangfire-with-asp-net-core/

```bash
# Cài hangfire như hướng dẫn trên web tham khảo
cài theo hướng dẫn này https://code-maze.com/hangfire-with-asp-net-core/
	1. Install-Package Hangfire
	2. Install-Package System.Data.SqlClient => để hangfire làm việc với sql
	

# Bổ sung vào program để đảm bảo job được thực hiện mà ko đứng chờ mãi ở enque:
      builder.Services.AddHangfireServer();


## Usage

Examples of how to use the project.

```bash
# Run the project
npm start
```

## Contributing

Nothing

## License

nothing