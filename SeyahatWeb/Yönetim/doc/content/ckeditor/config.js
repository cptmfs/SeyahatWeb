/**
 * @license Copyright (c) 2003-2017, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */
CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here.
    // For complete reference see:
    // //docs.ckeditor.com/#!/api/CKEDITOR.config

    // The toolbar groups arrangement, optimized for two toolbar rows.
    config.toolbarGroups = [
		{ name: 'clipboard', groups: ['clipboard', 'undo'] },
		{ name: 'links' },
		{ name: 'insert' },
		{ name: 'document', groups: ['mode', 'document', 'doctools'] },
		{ name: 'others' },
		'/',
		{ name: 'basicstyles', groups: ['basicstyles', 'cleanup'] },
		{ name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi'] },
		{ name: 'styles' },
		{ name: 'colors' }
    ];

    // Remove some buttons provided by the standard plugins, which are
    // not needed in the Standard(s) toolbar.
    config.removeButtons = 'Underline,Subscript,Superscript';

    

    // Set the most common block elements.
    config.format_tags = 'p;h1;h2;h3;pre';
    config.extraPlugins = 'colordialog';
    config.extraPlugins = 'colorbutton';    //Daha fazla renk seçeneði butonunu eklemek için kullanýldý
    config.colorButton_enableMore = true;  //Daha fazla renk seçeneði butonunu aktifleþtirmek için kullanýldý
    config.allowedContent = true;         // Style elementini tanýmasý için eklendi
    config.extraPlugins = 'widget';
    config.extraPlugins = 'notificationaggregator';
    config.extraPlugins = 'filetools';
    config.extraPlugins = 'lineutils';
    config.extraPlugins = 'widgetselection';
    config.extraPlugins = 'uploadimage';   //resim upload etmek için kullanýldý
    config.extraPlugins = 'uploadwidget';
    config.extraPlugins = 'image2';
    config.extraPlugins = 'filebrowser';
    config.imageUploadUrl = 'ResimYukle.ashx';
    config.uploadUrl = 'ResimYukle.ashx';
    // Simplify the dialog windows.
    config.removeDialogTabs = 'image:advanced;link:advanced';
};

