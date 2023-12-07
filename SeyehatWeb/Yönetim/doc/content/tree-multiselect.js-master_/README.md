## jQuery Tree Multiselect
[![Build Status](//travis-ci.org/patosai/tree-multiselect.js.svg?branch=master)](//travis-ci.org/patosai/tree-multiselect.js)
[![Coverage Status](//coveralls.io/repos/patosai/tree-multiselect.js/badge.svg?branch=master&service=github)](//coveralls.io/github/patosai/tree-multiselect.js?branch=master)
[![devDependency Status](//david-dm.org/patosai/tree-multiselect.js/dev-status.svg)](//david-dm.org/patosai/tree-multiselect.js#info=devDependencies)


**This plugin allows you to add a sweet treeview frontend to a `select` element.**
There seems to be a common misconception that the `select` you call this on is tossed into the void. All this does is make the selection process a little more organized. Your `select` element will still act the same in forms, in JavaScript, etc.

* Requires jQuery v1.8+
* Does not work on IE8. Pull requests welcome!

### Demo
<a target="_blank" href="//www.patosai.com/projects/tree-multiselect">My website has a simple demo running.</a>

### Usage
```
$("select").treeMultiselect();
```

Make sure your `select` has the `multiple` attribute set. Also, make sure you've got `<meta charset="UTF-8">` or some of the symbols may look strange.

Option Attribute name         | Description
----------------------------- | ---------------------------------
`selected`                    | Have the option pre-selected. This is actually part of the HTML spec
`data-section` **(required)** | The section the option will be in; can be nested
`data-description`            | A description of the attribute; will be shown on the multiselect
`data-index`                  | For pre-selected options, display options in this order, lowest index first. Conflicts will be overwritten by the last item with the same `data-index`

Your `data-section` can have multiple section names, separated by the `sectionDelimiter` option.

Ex. `data-section="top/middle/inner"` will show up as
- `top`
  - `middle`
    - `inner`
      - your option

#### Options
You can pass in options like `treeMultiselect(options)`. It is an object where you can set the following features:

Option name             | Default        | Description
----------------------- | -------------- | ---------------
`allowBatchSelection`   | `true`         | Sections have checkboxes which when checked, check everything within them
`collapsible`           | `true`         | Adds collapsibility to sections
`enableSelectAll`       | `false`        | Enables selection of all or no options
`selectAllText`         | `Select All`   | Only used if `enableSelectAll` is active
`unselectAllText`       | `Unselect All` | Only used if `enableSelectAll` is active
`freeze`                | `false`        | Disables selection/deselection of options; aka display-only
`hideSidePanel`         | `false`        | Hide the right panel showing all the selected items
`onChange`              | `null`         | Callback for when select is changed. Called with (allSelectedItems, addedItems, removedItems), each of which is an array of objects with the properties `text`, `value`, `initialIndex`, and `section`
`onlyBatchSelection`    | `false`        | Only sections can be checked, not individual items
`sortable`              | `false`        | Selected options can be sorted by dragging (requires jQuery UI)
`sectionDelimiter`      | `/`            | Separator between sections in the select option `data-section` attribute
`showSectionOnSelected` | `true`         | Show section name on the selected items
`startCollapsed`        | `false`        | Activated only if `collapsible` is true; sections are collapsed initially

### Installation
Load `jquery.tree-multiselect.min.js` on to your web page. The css file is optional (but recommended).

You can also use bower - `bower install tree-multiselect`

### Custom styling
So, you want to exercise your css-fu. Alright then.

The plugin adds a `div.tree-multiselect` immediately after the specified `select`. The hierarchy is shown below.

- `div.tree-multiselect`
  - `div.selections`
    - a lot of `div.section`, each of which has
      - `div.title`, which has
        - `span.collapse-section` holding the collapsible indicators if collapsibility is enabled
        - `input` of type `checkbox` for selection if allowBatchSelection is enabled
        - the title text
      - a lot of `div.item`, containing
        - `input` of type `checkbox` for selection
        - the item text
      - and possibly more `div.section`
  - `div.selected`
    - a lot of `div.item`, each containing...
      - `span.remove-selected` holding the indicator to remove element from selection
      - the option name
      - `span.section-name` if `showSectionOnSelected` is enabled, showing the section name(s)

### Testing
`grunt`

### FAQ
`Help! The first element is selected when I create the tree. How do I make the first element not selected?`
You didn't set the `multiple` attribute on your `select`. This is a property of single-option select nodes - the first option is selected.

`How do I dynamically change ___?`
Not supported... yet.

### License
MIT licensed.
