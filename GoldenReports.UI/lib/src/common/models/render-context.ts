import { RenderMode } from './render-mode';
import { createContext } from '@lit-labs/context';

export interface RenderContext {
  mode: RenderMode;
}

export const renderContext = createContext<RenderContext>('render-context');
