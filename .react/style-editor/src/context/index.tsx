import { ReactUnity, System as SystemNS } from '@reactunity/renderer';
import React, { useContext, useMemo, useRef } from "react";

type Cmp = ReactUnity.IReactComponent;
type Styles = Record<string, object>;

export interface ContextType {
  getStyles(cmp: Cmp): Styles;
  setProp(el: Cmp, prop: string, value: any): void;
  removeProp(el: Cmp, prop: string): void;
}

const styleContext = React.createContext<ContextType>(null);
export const useStyleContext = () => useContext(styleContext);

interface ElementProps {
  element: Cmp,
  styles: Styles;
  ind: number;
  sheet: any;
}

type State = ElementProps[];

const findElementId = (state: State, el: Cmp) => {
  let ind = state.findIndex(x => x.element === el);

  if (ind < 0) {
    ind = state.length;
    const st = { element: el, styles: {}, ind } as ElementProps;
    state.push(st);
    el.Id = 'style-editor-el-' + ind;
    el.SetData('style-editor-el', ind + '');
  }

  return ind;
};

const buildSheet = (state: ElementProps) => {
  const type = importType('ReactUnity.StyleEngine.StyleSheet') as any;
  const dicCtor = (System.Collections.Generic.Dictionary as any)(System.String, System.Object);

  const sheet = new type(state.element.Context.Style, '', 1);

  const style = state.styles;

  const selector = `#style-editor-el-${state.ind}`;

  const values = [];
  const valuesDic: SystemNS.Collections.Generic.Dictionary<string, any> = new dicCtor();

  for (const prop in style) {
    if (Object.prototype.hasOwnProperty.call(style, prop)) {
      const val = style[prop];
      values.push(`${prop}: ${val};\n`);
      valuesDic.Add(prop, val);
    }
  }

  if (values.length)
    sheet.AddRules(selector, valuesDic);

  state.sheet = sheet;

  return sheet;
};

const changed = (state: ElementProps) => {
  const ctx = state.element.Context;

  if (state.sheet) {
    ctx.RemoveStyle(state.sheet);
    state.sheet = null;
  }

  const newSheet = buildSheet(state);
  state.sheet = ctx.InsertStyle(newSheet);
};

export function StyleContext({ children }) {
  const state = useRef<State>([]);

  const ctx = useMemo(() => ({
    setProp: (el: Cmp, prop: string, value: any) => {
      const ind = findElementId(state.current, el);
      state.current[ind].styles[prop] = value;
      changed(state.current[ind]);
    },
    removeProp: (el: Cmp, prop: string) => {
      const ind = findElementId(state.current, el);
      Reflect.deleteProperty(state.current[ind].styles, prop);
      changed(state.current[ind]);
    },
    hasProp: (el: Cmp, prop: string) => {
      const ind = findElementId(state.current, el);
      return Object.prototype.hasOwnProperty.call(state.current[ind].styles, prop);
    },
    getProp: (el: Cmp, prop: string) => {
      const ind = findElementId(state.current, el);
      return state.current[ind].styles[prop];
    },
    getStyles: (el: Cmp) => {
      const ind = findElementId(state.current, el);
      return state.current[ind].styles;
    },
  }), []);

  return <styleContext.Provider value={ctx}>
    {children}
  </styleContext.Provider>;
}
