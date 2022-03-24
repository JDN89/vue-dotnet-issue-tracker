/// <reference types="vitest" />

import path from 'path'
import { defineConfig } from 'vite'
import Vue from '@vitejs/plugin-vue'
import Pages from 'vite-plugin-pages'
import Components from 'unplugin-vue-components/vite'
import AutoImport from 'unplugin-auto-import/vite'
import { presetAttributify, presetIcons, presetUno } from 'unocss'
import Unocss from 'unocss/vite'

export default defineConfig({
  resolve: {
    alias: {
      '~/': `${path.resolve(__dirname, 'src')}/`,
    },
  },
  plugins: [
    Vue(),

    // https://github.com/hannoeru/vite-plugin-pages
    Pages(),

    // https://github.com/antfu/unplugin-auto-import
    AutoImport({
      imports: [
        'vue',
        'vue-router',
        '@vueuse/core',
      ],
      dts: true,
    }),

    // https://github.com/antfu/vite-plugin-components
    Components({
      dts: true,
    }),

    // https://github.com/antfu/unocss
    Unocss({
      shortcuts: [
        ['btn', 'px-4 py-1 rounded inline-block bg-teal-600 text-white cursor-pointer hover:bg-teal-700 disabled:cursor-default disabled:bg-gray-600 disabled:opacity-50'],
        ['icon-btn', 'text-[0.9em] inline-block cursor-pointer select-none opacity-75 transition duration-200 ease-in-out hover:opacity-100 hover:text-teal-600'],
        ['field', 'border rounded-2xl hover:border-2 dark:border-1 dark:border-gray-400 dark:hover:border-light-100 hover:bg-blue-gray-100 dark:bg-dark-200 dark:hover:bg-gray-600 mx-auto min-w-xs my-2 pl-3 text-left overflow-hidden'],
        ['hover', 'cursor-pointer transform transition ease-in-out duration-200 duration-500  select-none sm:hover:scale-109 xl:hover:scale-110'],
        ['rounded-border', 'border rounded-2xl hover:border-2 dark:border-1 dark:border-gray-400 dark:hover:border-light-100'],
        ['square-border', 'border rounded-md hover:border-2 dark:border-1 dark:border-gray-400 dark:hover:border-light-100'],
        ['ghost', 'bg-teal-400'],
      ],
      presets: [
        presetUno(),
        presetAttributify(),
        presetIcons({
          scale: 1.2,
        }),
      ],
    }),
  ],

  // https://github.com/vitest-dev/vitest
  test: {
    environment: 'jsdom',
  },
})
