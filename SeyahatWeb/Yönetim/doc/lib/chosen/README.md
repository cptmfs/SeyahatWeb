# Chosen

Chosen is a library for making long, unwieldy select boxes more user friendly.

- jQuery support: 1.4+
- Prototype support: 1.7+

For documentation, usage, and examples, see:  
//harvesthq.github.com/chosen

### Contributing to Chosen

Contributions and pull requests are very welcome. Please follow these guidelines when submitting new code.

1. Make all changes in Coffeescript files, **not** JavaScript files.
2. For feature changes, update both jQuery *and* Prototype versions
3. Use `npm install -d` to install the correct development dependencies.
4. Use `cake build` or `cake watch` to generate Chosen's JavaScript file and minified version.
5. Don't touch the `VERSION` file
6. Submit a Pull Request using GitHub.

### Using CoffeeScript & Cake

First, make sure you have the proper CoffeeScript / Cake set-up in place. We have added a package.json that makes this easy:

```
npm install -d
```

This will install `coffee-script` and `uglifyjs`.

Once you're configured, building the JavasScript from the command line is easy:

    cake build                # build Chosen from source
    cake watch                # watch coffee/ for changes and build Chosen
    
If you're interested, you can find the recipes in Cakefile.


### Chosen Credits

- Built by [Harvest](//www.getharvest.com/). Want to work on projects like this? [We’re hiring](//www.getharvest.com/careers)!
- Concept and development by [Patrick Filler](//www.patrickfiller.com/)
- Design and CSS by [Matthew Lettini](//matthewlettini.com/)

### Notable Forks

- [Chosen for MooTools](//github.com/julesjanssen/chosen), by Jules Janssen
- [Chosen Drupal 7 Module](//drupal.org/project/chosen), by Pol Dell'Aiera, Arshad Chummun, Bart Feenstra, Kálmán Hosszu, etc.
- [Chosen CakePHP Plugin](//github.com/paulredmond/chosen-cakephp), by Paul Redmond
