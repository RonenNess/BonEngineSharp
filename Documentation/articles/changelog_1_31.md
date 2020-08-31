# 1.3.1

**[01/09/2020]**

Key changes:

- Fixed access violation with multiple long sound effects with pitch.
- Improved sound effects playing.

All Changes:

- Added more logs and signals handling.
- Added 'Flush' to logs.
- Made sound effects more efficient by doing less queries.
- Fixed log to flush after every line in debug mode.
- Added try-catch around main loop in debug mode.
- Added guard around assets deletion.
- Fixed access violation while playing multiple long sounds with pitch (happened randomly).
- Reduced memory allocations when using sound effects with pitch + made code safer against memory leaks.
- Added option to set log level from config file.
- Added option to turn off logging during init.
- Added 'Tag' to spritesheet animation steps.