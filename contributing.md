# How to Contribute
Open source projects thrive on contributions from the developer community. Would you like to get involved? There is plenty that you can do to help!

This is a general guide about how to contribute to Dapper.SimpleSave. It is not a set of hard and fast rules. Please raise any questions on the [Dapper.SimpleSave Developers List](https://groups.google.com/forum/#!forum/dappersimplesave-developers).

## Areas where we particularly need help

* Documentation - you won't need to read very far to realise that this is something I suck at, so I'd really appreciate your help if you're good at it.

* Testing - both Dapper.SimpleSave and Dapper.SimpleLoad have been fairly well tested in the context of the app for which they were originally developed. However, their own automated test suites are somewhat lacking - particularly in the case of SimpleLoad. SimpleSave primarily needs tests that hit a real database and verify what was saved, on top of what it already has, in addition to verification of the scripts that are being created.

* Support for RDBMS platforms other than SQL Server. In particular: Oracle, PostgreSQL, MySQL; possibly others. In theory this shouldn't bee too difficult because it just affects the script generation portion of the process. We can also take advantage of functionality, such as deferred referential integrity checks, offered by platforms such as Oracle.

## Submitting Issues

Bugs and feature requests should be reported in the [GitHub Issue](https://github.com/Paymentsense/Dapper.SimpleSave/issues) tracker if they have not been previously submitted. If there's already an issue filed please feel free to add more detail or contribute to the discussion on that issue.

When reporting a bug or issue, please include all pertinent information. This typically includes:

* Dapper.SimpleSave package installed _(Example: Dapper.SimpleSave 1.0.65)_

* Development platform, including .NET and SQL Server versions and web server (if relevant)_(Example: .NET 4.5.1 with SQL Server 2014 Developer Edition on IIS Express)_

* Steps to reproduce the bug/example code

* Any error messages and stack trace

It is also quite helpful to include the relevant portions of your log file since, if you have log4net configured, SimpleSave will write a record of scripts build and executed, along with any errors to it. Note that these are logged mostly at INFO level so you may need to tweak your log4net configuration to see them.

Bugs will be addressed as soon as humanly possible, but please allow ample time. For quicker responses, you may also choose to implement and contribute the bug fix via a pull request.

## Fixing Issues

Dapper.SimpleSave often maintains several issues that are good for first-timers [tagged as Jump In on GitHub](https://github.com/Paymentsense/Dapper.SimpleSave/issues?labels=Jump+In&milestone=&page=1&sort=updated&state=open). If one peaks your interest, feel free to work on it and let us know if you need any help doing so.

## New Features

For those looking to get more deeply involved, [reach out](https://groups.google.com/forum/#!forum/dappersimplesave-developers) to find out about our current efforts and how you can help. Medium or large contributions should begin by sending a message to the [Dapper.SimpleSave Developers List](https://groups.google.com/forum/#!forum/dappersimplesave-developers) or should start as a basic pull request so that a discussion can be started. (TODO)

The message should describe the contribution you are interested in making, and any initial thoughts on implementation. This will allow the community to discuss and become involved with you from the get go. If you receive positive feedback on the mailing list, go ahead and start implementation! You should also sign and return the [Contributor License Agreement](https://www.clahub.com/agreements/Paymentsense/Dapper.SimpleSave), which is required for the Dapper.SimpleSave team to accept your contribution.

The Dapper.SimpleSave team uses [the issue tracking features of GitHub](https://github.com/Paymentsense/Dapper.SimpleSave/issues) which is a good place to look through if you want to get involved but aren't quite sure how.

## Share Dapper.SimpleSave

If you love SimpleSave, tell others about it! Present SimpleSave at a company tech talk, your local user group or submit a proposal to a conference about how you are using SimpleSave.</p>

## Documentation

Documentation is a key differentiator between good projects and _great_ ones. Whether you’re a first time OSS contributor or a veteran, documentation is a great stepping stone to learn our contribution process.

Contributing to SimpleSave documentation is dead simple. To make it so easy, we're using SimpleSave's [GitHub Wiki](https://github.com/Paymentsense/Dapper.SimpleSave/wiki) as the entry point for documentation - each page within the docs section of the site has a link to take you straight to the page where you can make changes directly. GitHub Wikis provide an online WYSIWYG interface for adding and editing the docs, completely in browser, using [Markdown](https://daringfireball.net/projects/markdown/).

## Code Conventions

SimpleSave follows a loose set of coding conventions. Chiefly among them:

* Ensure all unit tests pass successfully

* Cover additional code with passing unit tests

* Try not to add any additional StyleCop warnings to the compilation process

* Try to avoid breaking API changes, unless there is exceptionally good reason for them

* Stick to the existing code style in terms of spaces, braces, naming conventions, etc. None of these are written down but you should be able to figure them out just by looking at the code.

* Ensure your [Git autocrlf setting](https://help.github.com/articles/dealing-with-line-endings) is false because we don't like our SCM to modify files.

## Additional Resources

* [General GitHub documentation](http://help.github.com/)

* [GitHub pull request documentation](http://help.github.com/send-pull-requests/)

